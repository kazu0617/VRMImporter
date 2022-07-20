#  NeosVRMImporter

![VRM](https://vrm.dev/_static/vrm_topheader.png)

A [NeosModLoader](https://github.com/zkxs/NeosModLoader) mod for [Neos VR](https://neos.com/) that enables the import of VRM models.

## Installation
1. Install [NeosModLoader](https://github.com/zkxs/NeosModLoader).
1. Place [VRMImporter.dll](https://github.com/kazu0617/VRMImporter/releases/tag/v1.0.0) into your `nml_mods` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\nml_mods` for a default install. You can create it if it's missing, or if you launch the game once with NeosModLoader installed it will create the folder for you.
1. Install and extract [Blender](https://www.blender.org/download/) to your Neos tools folder. This can be found under `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\tools\Blender` for a default install.
1. (可能なら入れなくてもいいようにしたい)vrmconv.pyを含むスクリプト群を以下から落として下さい。落とした後解凍して適切な階層に配置。
1. (可能なら入れなくてもいいようにしたい)[ここ](https://vrm-addon-for-blender.info/ja/)から最新版を落として階層に入れる。インストールは必要なくできそう。ダメならあっさりあきらめるけど。
1. Start the game. If you want to verify that the mod is working you can check your Neos logs.

Tested only on Windows. Depending on the size of the file, it may take up to a few minutes to fully import. It's OK if the import dialogue seems to hang on "Preimporting" for a little bit - this is where the bulk of the conversion is done.

### Credits
- Thanks to [badhaloninja](https://github.com/badhaloninja) for reflection help
- Thanks to [Roger Kaufman](http://www.interocitors.com/polyhedra/vr1tovr2/) for their VRML 1.0 to VRML 2.0 converter
