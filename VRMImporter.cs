using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using FrooxEngine;
using BaseX;
using CodeX;
using HarmonyLib;
using NeosModLoader;

namespace VRMImporter
{
    public class VRMImporter : NeosMod
    {
        public override string Name => "VRMImporter";
        public override string Author => "kazu0617";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/dfgHiatus/VRMImporter/";
        public static ModConfiguration config;

        //ダウンロードしたファイルの保存先
        string addonName = "VRM_Addon_for_Blender-release";
        public override void OnEngineInit()
        {
            new Harmony("net.kazu0617.VRMImporter").PatchAll();
            config = GetConfiguration();
            Engine.Current.RunPostInit(() => AssetPatch());
        }

        public static void AssetPatch()
        {
            var aExt = Traverse.Create(typeof(AssetHelper)).Field<Dictionary<AssetClass, List<string>>>("associatedExtensions");
            aExt.Value[AssetClass.Model].Add("vrm");
        }

        [HarmonyPatch(typeof(ModelPreimporter), "Preimport")]
        public class FileImporterPatch
        {
            public static void Postfix(ref string __result, string model, string tempPath)
            {
                string normalizedExtension = Path.GetExtension(model).Replace(".", "").ToLower();
                if(normalizedExtension == "vrm" && BlenderInterface.IsAvailable)
                {
                    var time = DateTime.Now.Ticks.ToString();
                    string blenderTarget = Path.Combine(Path.GetDirectoryName(model), $"{Path.GetFileNameWithoutExtension(model)}_v2_{time}.glb");
                    ConvertToGLTF(model, blenderTarget);
                    __result = blenderTarget;
                    return;
                }
            }

            private static void ConvertToGLTF(string input, string output)
            {
                // TODO ここにスクリプトを書くか読み込み方式を変える
                RunBlenderScript($"write script");
            }

            private static void RunBlenderScript(string script, string arguments = "-b -P \"{0}\"")
            {
                string tempBlenderScript = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".py");
                File.WriteAllText(tempBlenderScript, script);
                string blenderArgs = string.Format(arguments, tempBlenderScript);
                blenderArgs = "--disable-autoexec " + blenderArgs;
                Process.Start(new ProcessStartInfo(BlenderInterface.Executable, blenderArgs)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false
                }).WaitForExit();
                File.Delete(tempBlenderScript);
            }
        }
    }
}