; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [334 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [662 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 3: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 253
	i32 34715100, ; 4: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 287
	i32 34839235, ; 5: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39485524, ; 6: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 7: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 8: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 9: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 328
	i32 68219467, ; 10: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 11: Microsoft.Maui.Graphics.dll => 0x44bb714 => 210
	i32 82292897, ; 12: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 98325684, ; 13: Microsoft.Extensions.Diagnostics.Abstractions => 0x5dc54b4 => 191
	i32 101534019, ; 14: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 271
	i32 117431740, ; 15: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 16: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 271
	i32 122350210, ; 17: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 134690465, ; 18: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 291
	i32 142721839, ; 19: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 20: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 21: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 22: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 227
	i32 176265551, ; 23: System.ServiceProcess => 0xa81994f => 132
	i32 182336117, ; 24: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 273
	i32 184328833, ; 25: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 26: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 325
	i32 199333315, ; 27: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 326
	i32 205061960, ; 28: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 29: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 225
	i32 220171995, ; 30: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 221958352, ; 31: Microsoft.Extensions.Diagnostics.dll => 0xd3ad0d0 => 190
	i32 230216969, ; 32: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 247
	i32 230752869, ; 33: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 34: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 35: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 36: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 254259026, ; 37: Microsoft.AspNetCore.Components.dll => 0xf27af52 => 177
	i32 261689757, ; 38: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 230
	i32 276479776, ; 39: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 40: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 249
	i32 280482487, ; 41: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 246
	i32 280992041, ; 42: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 297
	i32 291076382, ; 43: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 291275502, ; 44: Microsoft.Extensions.Http.dll => 0x115c82ee => 197
	i32 298918909, ; 45: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 46: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 325
	i32 318968648, ; 47: Xamarin.AndroidX.Activity.dll => 0x13031348 => 216
	i32 321597661, ; 48: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 49: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 310
	i32 342366114, ; 50: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 248
	i32 356389973, ; 51: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 309
	i32 360082299, ; 52: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 53: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 54: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 55: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 56: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 57: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 58: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 59: _Microsoft.Android.Resource.Designer => 0x17969339 => 330
	i32 403441872, ; 60: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 61: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 321
	i32 441335492, ; 62: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 231
	i32 442565967, ; 63: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 64: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 244
	i32 451504562, ; 65: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 66: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 67: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 68: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 69: System.dll => 0x1bff388e => 164
	i32 476646585, ; 70: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 246
	i32 486930444, ; 71: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 259
	i32 498788369, ; 72: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 73: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 308
	i32 503918385, ; 74: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 302
	i32 513247710, ; 75: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 203
	i32 525313283, ; 76: BookingSystem.Mobile.App => 0x1f4fa503 => 0
	i32 526420162, ; 77: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 78: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 291
	i32 530272170, ; 79: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 80: Microsoft.Extensions.Logging => 0x20216150 => 198
	i32 540030774, ; 81: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 82: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 83: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 84: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 557405415, ; 85: Jsr305Binding => 0x213954e7 => 284
	i32 569601784, ; 86: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 282
	i32 571435654, ; 87: Microsoft.Extensions.FileProviders.Embedded.dll => 0x220f6a86 => 194
	i32 577335427, ; 88: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 89: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 316
	i32 601371474, ; 90: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 91: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 92: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 93: Xamarin.AndroidX.CustomView => 0x2568904f => 236
	i32 627931235, ; 94: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 314
	i32 639843206, ; 95: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 242
	i32 643868501, ; 96: System.Net => 0x2660a755 => 81
	i32 662205335, ; 97: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 98: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 278
	i32 666292255, ; 99: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 223
	i32 672442732, ; 100: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 101: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 102: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 296
	i32 690569205, ; 103: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 104: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 293
	i32 693804605, ; 105: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 106: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 107: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 288
	i32 700358131, ; 108: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 109: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 311
	i32 709557578, ; 110: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 299
	i32 720511267, ; 111: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 292
	i32 722857257, ; 112: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 731701662, ; 113: Microsoft.Extensions.Options.ConfigurationExtensions => 0x2b9ce19e => 202
	i32 735137430, ; 114: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 115: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 116: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 213
	i32 759454413, ; 117: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 118: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 119: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 120: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 320
	i32 789151979, ; 121: Microsoft.Extensions.Options => 0x2f0980eb => 201
	i32 790371945, ; 122: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 237
	i32 804008546, ; 123: Microsoft.AspNetCore.Components.WebView.Maui => 0x2fec3262 => 181
	i32 804715423, ; 124: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 125: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 251
	i32 823281589, ; 126: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 127: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 128: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 129: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 130: Xamarin.AndroidX.Print => 0x3246f6cd => 264
	i32 873119928, ; 131: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 132: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 133: System.Net.Http.Json => 0x3463c971 => 63
	i32 904024072, ; 134: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 135: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 136: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 323
	i32 928116545, ; 137: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 287
	i32 952186615, ; 138: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 956575887, ; 139: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 292
	i32 966729478, ; 140: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 285
	i32 967690846, ; 141: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 248
	i32 975236339, ; 142: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 143: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 144: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 145: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 146: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 147: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 999186168, ; 148: Microsoft.Extensions.FileSystemGlobbing.dll => 0x3b8e5ef8 => 196
	i32 1001831731, ; 149: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 150: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 268
	i32 1019214401, ; 151: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 152: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 189
	i32 1029334545, ; 153: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 298
	i32 1031528504, ; 154: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 286
	i32 1035644815, ; 155: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 221
	i32 1036536393, ; 156: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 157: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1048992957, ; 158: Microsoft.Extensions.Diagnostics.Abstractions.dll => 0x3e865cbd => 191
	i32 1052210849, ; 159: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 255
	i32 1067306892, ; 160: GoogleGson => 0x3f9dcf8c => 175
	i32 1082857460, ; 161: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 162: Xamarin.Kotlin.StdLib => 0x409e66d8 => 289
	i32 1098259244, ; 163: System => 0x41761b2c => 164
	i32 1106973742, ; 164: Microsoft.Extensions.Configuration.FileExtensions.dll => 0x41fb142e => 186
	i32 1118262833, ; 165: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 311
	i32 1121599056, ; 166: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 254
	i32 1127624469, ; 167: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 200
	i32 1149092582, ; 168: Xamarin.AndroidX.Window => 0x447dc2e6 => 281
	i32 1168523401, ; 169: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 317
	i32 1170634674, ; 170: System.Web.dll => 0x45c677b2 => 153
	i32 1173126369, ; 171: Microsoft.Extensions.FileProviders.Abstractions.dll => 0x45ec7ce1 => 192
	i32 1175144683, ; 172: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 277
	i32 1178241025, ; 173: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 262
	i32 1203215381, ; 174: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 315
	i32 1204270330, ; 175: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 223
	i32 1208641965, ; 176: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 177: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 178: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 313
	i32 1243150071, ; 179: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 282
	i32 1253011324, ; 180: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 181: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 297
	i32 1264511973, ; 182: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 272
	i32 1267360935, ; 183: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 276
	i32 1273260888, ; 184: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 228
	i32 1275534314, ; 185: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 293
	i32 1278448581, ; 186: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 220
	i32 1293217323, ; 187: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 239
	i32 1309188875, ; 188: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1322716291, ; 189: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 281
	i32 1324164729, ; 190: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 191: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 192: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 193: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 327
	i32 1376866003, ; 194: Xamarin.AndroidX.SavedState => 0x52114ed3 => 268
	i32 1379779777, ; 195: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 196: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 197: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 232
	i32 1408764838, ; 198: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 199: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 200: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 201: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 295
	i32 1434145427, ; 202: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 203: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 285
	i32 1439761251, ; 204: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 205: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1452416952, ; 206: AutoMapper => 0x56921fb8 => 173
	i32 1453312822, ; 207: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1454105418, ; 208: Microsoft.Extensions.FileProviders.Composite => 0x56abe34a => 193
	i32 1457743152, ; 209: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 210: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1461004990, ; 211: es\Microsoft.Maui.Controls.resources => 0x57152abe => 301
	i32 1461234159, ; 212: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 213: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 214: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 215: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 222
	i32 1470490898, ; 216: Microsoft.Extensions.Primitives => 0x57a5e912 => 203
	i32 1479771757, ; 217: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 218: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 219: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 220: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 269
	i32 1493001747, ; 221: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 305
	i32 1505131794, ; 222: Microsoft.Extensions.Http => 0x59b67d12 => 197
	i32 1514721132, ; 223: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 300
	i32 1521091094, ; 224: Microsoft.Extensions.FileSystemGlobbing => 0x5aaa0216 => 196
	i32 1536373174, ; 225: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 226: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 227: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1546581739, ; 228: Microsoft.AspNetCore.Components.WebView.Maui.dll => 0x5c2ef6eb => 181
	i32 1550322496, ; 229: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 230: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 320
	i32 1565862583, ; 231: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 232: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 233: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 234: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 235: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 238
	i32 1592978981, ; 236: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 237: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 286
	i32 1601112923, ; 238: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 239: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1608315534, ; 240: BookingSystem.Shared => 0x5fdcf28e => 329
	i32 1618516317, ; 241: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 242: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 258
	i32 1622358360, ; 243: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 244: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 280
	i32 1632842087, ; 245: Microsoft.Extensions.Configuration.Json => 0x61533167 => 187
	i32 1635184631, ; 246: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 242
	i32 1636350590, ; 247: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 235
	i32 1639515021, ; 248: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 249: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 250: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1654881142, ; 251: Microsoft.AspNetCore.Components.WebView => 0x62a37b76 => 180
	i32 1657153582, ; 252: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 253: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 274
	i32 1658251792, ; 254: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 283
	i32 1670060433, ; 255: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 230
	i32 1675553242, ; 256: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 257: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 258: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679018464, ; 259: Blazored.LocalStorage => 0x6413c9e0 => 174
	i32 1679769178, ; 260: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 261: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 262: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 263: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 290
	i32 1701541528, ; 264: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 265: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 251
	i32 1726116996, ; 266: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 267: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 268: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 226
	i32 1736233607, ; 269: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 318
	i32 1743415430, ; 270: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 296
	i32 1744735666, ; 271: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746115085, ; 272: System.IO.Pipelines.dll => 0x68139a0d => 211
	i32 1746316138, ; 273: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 274: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 275: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1760259689, ; 276: Microsoft.AspNetCore.Components.Web.dll => 0x68eb6e69 => 179
	i32 1763938596, ; 277: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 278: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 279: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 273
	i32 1770582343, ; 280: Microsoft.Extensions.Logging.dll => 0x6988f147 => 198
	i32 1776026572, ; 281: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 282: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 283: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 284: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 312
	i32 1788241197, ; 285: Xamarin.AndroidX.Fragment => 0x6a96652d => 244
	i32 1793755602, ; 286: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 304
	i32 1808609942, ; 287: Xamarin.AndroidX.Loader => 0x6bcd3296 => 258
	i32 1813058853, ; 288: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 289
	i32 1813201214, ; 289: Xamarin.Google.Android.Material => 0x6c13413e => 283
	i32 1818569960, ; 290: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 263
	i32 1818787751, ; 291: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 292: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 293: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 294: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 199
	i32 1842015223, ; 295: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 324
	i32 1847515442, ; 296: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 213
	i32 1853025655, ; 297: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 321
	i32 1858542181, ; 298: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 299: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875935024, ; 300: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 303
	i32 1879696579, ; 301: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 302: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 224
	i32 1888955245, ; 303: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 304: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 305: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 306: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 307: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 308: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 309: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 310: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 270
	i32 1968388702, ; 311: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 183
	i32 1983156543, ; 312: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 290
	i32 1985761444, ; 313: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 215
	i32 2003115576, ; 314: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 300
	i32 2011961780, ; 315: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 316: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 255
	i32 2025202353, ; 317: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 295
	i32 2031445118, ; 318: AutoMapper.dll => 0x7915647e => 173
	i32 2031763787, ; 319: Xamarin.Android.Glide => 0x791a414b => 212
	i32 2045470958, ; 320: System.Private.Xml => 0x79eb68ee => 88
	i32 2048278909, ; 321: Microsoft.Extensions.Configuration.Binder.dll => 0x7a16417d => 185
	i32 2055257422, ; 322: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 250
	i32 2060060697, ; 323: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 324: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 299
	i32 2070888862, ; 325: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2072397586, ; 326: Microsoft.Extensions.FileProviders.Physical => 0x7b864712 => 195
	i32 2079903147, ; 327: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 328: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 329: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 330: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 331: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 332: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 333: Microsoft.Maui => 0x80bd55ad => 208
	i32 2169148018, ; 334: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 307
	i32 2181898931, ; 335: Microsoft.Extensions.Options.dll => 0x820d22b3 => 201
	i32 2192057212, ; 336: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 199
	i32 2193016926, ; 337: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 338: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 294
	i32 2201231467, ; 339: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 340: it\Microsoft.Maui.Controls.resources => 0x839595db => 309
	i32 2217644978, ; 341: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 277
	i32 2222056684, ; 342: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 343: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 259
	i32 2252106437, ; 344: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 345: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 346: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 347: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 184
	i32 2267999099, ; 348: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 214
	i32 2270573516, ; 349: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 303
	i32 2275479588, ; 350: BookingSystem.Shared.dll => 0x87a11024 => 329
	i32 2279755925, ; 351: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 266
	i32 2293034957, ; 352: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 353: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 354: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 355: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 313
	i32 2305521784, ; 356: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2311968808, ; 357: Blazored.LocalStorage.dll => 0x89cdd828 => 174
	i32 2315684594, ; 358: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 218
	i32 2320631194, ; 359: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2340441535, ; 360: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 361: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 362: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 363: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2371007202, ; 364: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 183
	i32 2378619854, ; 365: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 366: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 367: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 308
	i32 2401565422, ; 368: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 369: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 241
	i32 2411328690, ; 370: Microsoft.AspNetCore.Components => 0x8fb9f4b2 => 177
	i32 2421380589, ; 371: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 372: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 228
	i32 2427813419, ; 373: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 305
	i32 2435356389, ; 374: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 375: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2442556106, ; 376: Microsoft.JSInterop.dll => 0x919672ca => 204
	i32 2454642406, ; 377: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 378: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 379: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 380: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 231
	i32 2471841756, ; 381: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 382: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 383: Microsoft.Maui.Controls => 0x93dba8a1 => 206
	i32 2483903535, ; 384: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 385: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 386: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 387: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 388: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 253
	i32 2522472828, ; 389: Xamarin.Android.Glide.dll => 0x9659e17c => 212
	i32 2537015816, ; 390: Microsoft.AspNetCore.Authorization => 0x9737ca08 => 176
	i32 2538310050, ; 391: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 392: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 306
	i32 2562349572, ; 393: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 394: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 395: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 254
	i32 2581819634, ; 396: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 276
	i32 2585220780, ; 397: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 398: System.Net.Ping => 0x9a20430d => 69
	i32 2585813321, ; 399: Microsoft.AspNetCore.Components.Forms => 0x9a206149 => 178
	i32 2589602615, ; 400: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2592341985, ; 401: Microsoft.Extensions.FileProviders.Abstractions => 0x9a83ffe1 => 192
	i32 2593496499, ; 402: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 315
	i32 2605712449, ; 403: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 294
	i32 2615233544, ; 404: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 245
	i32 2616218305, ; 405: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 200
	i32 2617129537, ; 406: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 407: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 408: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 235
	i32 2624644809, ; 409: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 240
	i32 2626831493, ; 410: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 310
	i32 2627185994, ; 411: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 412: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 413: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 249
	i32 2663391936, ; 414: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 214
	i32 2663698177, ; 415: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 416: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 417: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 418: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 419: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2692077919, ; 420: Microsoft.AspNetCore.Components.WebView.dll => 0xa075d95f => 180
	i32 2693849962, ; 421: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 422: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 274
	i32 2715334215, ; 423: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 424: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 425: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 426: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 427: Xamarin.AndroidX.Activity => 0xa2e0939b => 216
	i32 2735172069, ; 428: System.Threading.Channels => 0xa30769e5 => 139
	i32 2735631878, ; 429: Microsoft.AspNetCore.Authorization.dll => 0xa30e6e06 => 176
	i32 2737747696, ; 430: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 222
	i32 2740948882, ; 431: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 432: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 433: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 316
	i32 2758225723, ; 434: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 207
	i32 2764765095, ; 435: Microsoft.Maui.dll => 0xa4caf7a7 => 208
	i32 2765824710, ; 436: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 437: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 288
	i32 2778768386, ; 438: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 279
	i32 2779977773, ; 439: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 267
	i32 2785988530, ; 440: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 322
	i32 2788224221, ; 441: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 245
	i32 2801831435, ; 442: Microsoft.Maui.Graphics => 0xa7008e0b => 210
	i32 2803228030, ; 443: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 444: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 301
	i32 2810250172, ; 445: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 232
	i32 2819470561, ; 446: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 447: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 448: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 267
	i32 2824502124, ; 449: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 450: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 314
	i32 2833784645, ; 451: Microsoft.AspNetCore.Metadata => 0xa8e81f45 => 182
	i32 2838993487, ; 452: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 256
	i32 2849599387, ; 453: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 454: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 279
	i32 2855708567, ; 455: Xamarin.AndroidX.Transition => 0xaa36a797 => 275
	i32 2861098320, ; 456: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 457: Microsoft.Maui.Essentials => 0xaa8a4878 => 209
	i32 2870099610, ; 458: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 217
	i32 2875164099, ; 459: Jsr305Binding.dll => 0xab5f85c3 => 284
	i32 2875220617, ; 460: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 461: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 243
	i32 2887636118, ; 462: System.Net.dll => 0xac1dd496 => 81
	i32 2892341533, ; 463: Microsoft.AspNetCore.Components.Web => 0xac65a11d => 179
	i32 2899753641, ; 464: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 465: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 466: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 467: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 468: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2911054922, ; 469: Microsoft.Extensions.FileProviders.Physical.dll => 0xad832c4a => 195
	i32 2916838712, ; 470: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 280
	i32 2919462931, ; 471: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 472: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 219
	i32 2936416060, ; 473: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 474: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 475: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 476: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 477: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2971004615, ; 478: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 0xb115eec7 => 202
	i32 2972252294, ; 479: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 480: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 239
	i32 2987532451, ; 481: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 270
	i32 2996846495, ; 482: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 252
	i32 3016983068, ; 483: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 272
	i32 3020703001, ; 484: Microsoft.Extensions.Diagnostics => 0xb40c4519 => 190
	i32 3023353419, ; 485: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 486: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 247
	i32 3038032645, ; 487: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 330
	i32 3056245963, ; 488: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 269
	i32 3057625584, ; 489: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 260
	i32 3059408633, ; 490: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 491: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 492: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 493: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 307
	i32 3090735792, ; 494: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 495: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 496: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 497: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 498: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 499: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 500: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3147165239, ; 501: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 502: GoogleGson.dll => 0xbba64c02 => 175
	i32 3159123045, ; 503: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 504: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 505: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 261
	i32 3192346100, ; 506: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 507: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 508: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 509: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 510: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 238
	i32 3220365878, ; 511: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 512: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 513: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 514: Xamarin.AndroidX.CardView => 0xc235e84d => 226
	i32 3265493905, ; 515: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 516: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 517: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 518: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 519: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 520: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 521: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 522: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 523: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 302
	i32 3316684772, ; 524: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 525: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 236
	i32 3317144872, ; 526: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 527: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 224
	i32 3345895724, ; 528: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 265
	i32 3346324047, ; 529: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 262
	i32 3357674450, ; 530: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 319
	i32 3358260929, ; 531: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 532: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 217
	i32 3362522851, ; 533: Xamarin.AndroidX.Core => 0xc86c06e3 => 233
	i32 3366347497, ; 534: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 535: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 266
	i32 3381016424, ; 536: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 298
	i32 3395150330, ; 537: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 538: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 539: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 237
	i32 3406629867, ; 540: Microsoft.Extensions.FileProviders.Composite.dll => 0xcb0d0beb => 193
	i32 3421170118, ; 541: Microsoft.Extensions.Configuration.Binder => 0xcbeae9c6 => 185
	i32 3428513518, ; 542: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 188
	i32 3429136800, ; 543: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 544: netstandard => 0xcc7d82b4 => 167
	i32 3441283291, ; 545: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 240
	i32 3445260447, ; 546: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 547: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 205
	i32 3463511458, ; 548: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 306
	i32 3464190856, ; 549: Microsoft.AspNetCore.Components.Forms.dll => 0xce7b5b88 => 178
	i32 3471940407, ; 550: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 551: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 552: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 319
	i32 3484440000, ; 553: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 318
	i32 3485117614, ; 554: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 555: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 556: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 229
	i32 3500000672, ; 557: Microsoft.JSInterop => 0xd09dc5a0 => 204
	i32 3509114376, ; 558: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 559: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 560: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 561: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 562: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 563: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 564: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 326
	i32 3597029428, ; 565: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 215
	i32 3598340787, ; 566: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 567: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 568: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 569: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 264
	i32 3633644679, ; 570: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 219
	i32 3638274909, ; 571: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 572: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 250
	i32 3643446276, ; 573: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 323
	i32 3643854240, ; 574: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 261
	i32 3645089577, ; 575: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 576: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 184
	i32 3660523487, ; 577: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 578: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 579: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 225
	i32 3684561358, ; 580: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 229
	i32 3697841164, ; 581: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 328
	i32 3700866549, ; 582: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 583: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 234
	i32 3716563718, ; 584: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 585: Xamarin.AndroidX.Annotation => 0xdda814c6 => 218
	i32 3722202641, ; 586: Microsoft.Extensions.Configuration.Json.dll => 0xdddc4e11 => 187
	i32 3724971120, ; 587: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 260
	i32 3732100267, ; 588: System.Net.NameResolution => 0xde7354ab => 67
	i32 3732214720, ; 589: Microsoft.AspNetCore.Metadata.dll => 0xde7513c0 => 182
	i32 3737834244, ; 590: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 591: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 592: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3758424670, ; 593: Microsoft.Extensions.Configuration.FileExtensions => 0xe005025e => 186
	i32 3786282454, ; 594: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 227
	i32 3792276235, ; 595: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 596: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 205
	i32 3802395368, ; 597: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 598: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 599: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 600: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 601: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 189
	i32 3844307129, ; 602: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 603: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3870376305, ; 604: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 605: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 606: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 607: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 608: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 275
	i32 3888767677, ; 609: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 265
	i32 3889960447, ; 610: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 327
	i32 3896106733, ; 611: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 612: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 233
	i32 3901907137, ; 613: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 614: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 615: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 278
	i32 3928044579, ; 616: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 617: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 618: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 263
	i32 3945713374, ; 619: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 620: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 621: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 221
	i32 3959773229, ; 622: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 252
	i32 3980434154, ; 623: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 322
	i32 3987592930, ; 624: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 304
	i32 4003436829, ; 625: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 626: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 220
	i32 4023392905, ; 627: System.IO.Pipelines => 0xefd01a89 => 211
	i32 4025784931, ; 628: System.Memory => 0xeff49a63 => 62
	i32 4046471985, ; 629: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 207
	i32 4054681211, ; 630: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 631: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4069119681, ; 632: BookingSystem.Mobile.App.dll => 0xf289d6c1 => 0
	i32 4073602200, ; 633: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 634: Microsoft.Maui.Essentials.dll => 0xf40add04 => 209
	i32 4099507663, ; 635: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 636: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 637: Xamarin.AndroidX.Emoji2 => 0xf479582c => 241
	i32 4102112229, ; 638: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 317
	i32 4125707920, ; 639: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 312
	i32 4126470640, ; 640: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 188
	i32 4127667938, ; 641: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 642: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 643: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 644: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 324
	i32 4151237749, ; 645: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 646: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 647: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 648: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 649: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 650: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 257
	i32 4185676441, ; 651: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 652: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 653: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 654: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 234
	i32 4258378803, ; 655: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 256
	i32 4260525087, ; 656: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 657: Microsoft.Maui.Controls.dll => 0xfea12dee => 206
	i32 4274976490, ; 658: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 659: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 257
	i32 4294648842, ; 660: Microsoft.Extensions.FileProviders.Embedded => 0xfffb240a => 194
	i32 4294763496 ; 661: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 243
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [662 x i32] [
	i32 68, ; 0
	i32 67, ; 1
	i32 108, ; 2
	i32 253, ; 3
	i32 287, ; 4
	i32 48, ; 5
	i32 80, ; 6
	i32 145, ; 7
	i32 30, ; 8
	i32 328, ; 9
	i32 124, ; 10
	i32 210, ; 11
	i32 102, ; 12
	i32 191, ; 13
	i32 271, ; 14
	i32 107, ; 15
	i32 271, ; 16
	i32 139, ; 17
	i32 291, ; 18
	i32 77, ; 19
	i32 124, ; 20
	i32 13, ; 21
	i32 227, ; 22
	i32 132, ; 23
	i32 273, ; 24
	i32 151, ; 25
	i32 325, ; 26
	i32 326, ; 27
	i32 18, ; 28
	i32 225, ; 29
	i32 26, ; 30
	i32 190, ; 31
	i32 247, ; 32
	i32 1, ; 33
	i32 59, ; 34
	i32 42, ; 35
	i32 91, ; 36
	i32 177, ; 37
	i32 230, ; 38
	i32 147, ; 39
	i32 249, ; 40
	i32 246, ; 41
	i32 297, ; 42
	i32 54, ; 43
	i32 197, ; 44
	i32 69, ; 45
	i32 325, ; 46
	i32 216, ; 47
	i32 83, ; 48
	i32 310, ; 49
	i32 248, ; 50
	i32 309, ; 51
	i32 131, ; 52
	i32 55, ; 53
	i32 149, ; 54
	i32 74, ; 55
	i32 145, ; 56
	i32 62, ; 57
	i32 146, ; 58
	i32 330, ; 59
	i32 165, ; 60
	i32 321, ; 61
	i32 231, ; 62
	i32 12, ; 63
	i32 244, ; 64
	i32 125, ; 65
	i32 152, ; 66
	i32 113, ; 67
	i32 166, ; 68
	i32 164, ; 69
	i32 246, ; 70
	i32 259, ; 71
	i32 84, ; 72
	i32 308, ; 73
	i32 302, ; 74
	i32 203, ; 75
	i32 0, ; 76
	i32 150, ; 77
	i32 291, ; 78
	i32 60, ; 79
	i32 198, ; 80
	i32 51, ; 81
	i32 103, ; 82
	i32 114, ; 83
	i32 40, ; 84
	i32 284, ; 85
	i32 282, ; 86
	i32 194, ; 87
	i32 120, ; 88
	i32 316, ; 89
	i32 52, ; 90
	i32 44, ; 91
	i32 119, ; 92
	i32 236, ; 93
	i32 314, ; 94
	i32 242, ; 95
	i32 81, ; 96
	i32 136, ; 97
	i32 278, ; 98
	i32 223, ; 99
	i32 8, ; 100
	i32 73, ; 101
	i32 296, ; 102
	i32 155, ; 103
	i32 293, ; 104
	i32 154, ; 105
	i32 92, ; 106
	i32 288, ; 107
	i32 45, ; 108
	i32 311, ; 109
	i32 299, ; 110
	i32 292, ; 111
	i32 109, ; 112
	i32 202, ; 113
	i32 129, ; 114
	i32 25, ; 115
	i32 213, ; 116
	i32 72, ; 117
	i32 55, ; 118
	i32 46, ; 119
	i32 320, ; 120
	i32 201, ; 121
	i32 237, ; 122
	i32 181, ; 123
	i32 22, ; 124
	i32 251, ; 125
	i32 86, ; 126
	i32 43, ; 127
	i32 160, ; 128
	i32 71, ; 129
	i32 264, ; 130
	i32 3, ; 131
	i32 42, ; 132
	i32 63, ; 133
	i32 16, ; 134
	i32 53, ; 135
	i32 323, ; 136
	i32 287, ; 137
	i32 105, ; 138
	i32 292, ; 139
	i32 285, ; 140
	i32 248, ; 141
	i32 34, ; 142
	i32 158, ; 143
	i32 85, ; 144
	i32 32, ; 145
	i32 12, ; 146
	i32 51, ; 147
	i32 196, ; 148
	i32 56, ; 149
	i32 268, ; 150
	i32 36, ; 151
	i32 189, ; 152
	i32 298, ; 153
	i32 286, ; 154
	i32 221, ; 155
	i32 35, ; 156
	i32 58, ; 157
	i32 191, ; 158
	i32 255, ; 159
	i32 175, ; 160
	i32 17, ; 161
	i32 289, ; 162
	i32 164, ; 163
	i32 186, ; 164
	i32 311, ; 165
	i32 254, ; 166
	i32 200, ; 167
	i32 281, ; 168
	i32 317, ; 169
	i32 153, ; 170
	i32 192, ; 171
	i32 277, ; 172
	i32 262, ; 173
	i32 315, ; 174
	i32 223, ; 175
	i32 29, ; 176
	i32 52, ; 177
	i32 313, ; 178
	i32 282, ; 179
	i32 5, ; 180
	i32 297, ; 181
	i32 272, ; 182
	i32 276, ; 183
	i32 228, ; 184
	i32 293, ; 185
	i32 220, ; 186
	i32 239, ; 187
	i32 85, ; 188
	i32 281, ; 189
	i32 61, ; 190
	i32 112, ; 191
	i32 57, ; 192
	i32 327, ; 193
	i32 268, ; 194
	i32 99, ; 195
	i32 19, ; 196
	i32 232, ; 197
	i32 111, ; 198
	i32 101, ; 199
	i32 102, ; 200
	i32 295, ; 201
	i32 104, ; 202
	i32 285, ; 203
	i32 71, ; 204
	i32 38, ; 205
	i32 173, ; 206
	i32 32, ; 207
	i32 193, ; 208
	i32 103, ; 209
	i32 73, ; 210
	i32 301, ; 211
	i32 9, ; 212
	i32 123, ; 213
	i32 46, ; 214
	i32 222, ; 215
	i32 203, ; 216
	i32 9, ; 217
	i32 43, ; 218
	i32 4, ; 219
	i32 269, ; 220
	i32 305, ; 221
	i32 197, ; 222
	i32 300, ; 223
	i32 196, ; 224
	i32 31, ; 225
	i32 138, ; 226
	i32 92, ; 227
	i32 181, ; 228
	i32 93, ; 229
	i32 320, ; 230
	i32 49, ; 231
	i32 141, ; 232
	i32 112, ; 233
	i32 140, ; 234
	i32 238, ; 235
	i32 115, ; 236
	i32 286, ; 237
	i32 157, ; 238
	i32 76, ; 239
	i32 329, ; 240
	i32 79, ; 241
	i32 258, ; 242
	i32 37, ; 243
	i32 280, ; 244
	i32 187, ; 245
	i32 242, ; 246
	i32 235, ; 247
	i32 64, ; 248
	i32 138, ; 249
	i32 15, ; 250
	i32 180, ; 251
	i32 116, ; 252
	i32 274, ; 253
	i32 283, ; 254
	i32 230, ; 255
	i32 48, ; 256
	i32 70, ; 257
	i32 80, ; 258
	i32 174, ; 259
	i32 126, ; 260
	i32 94, ; 261
	i32 121, ; 262
	i32 290, ; 263
	i32 26, ; 264
	i32 251, ; 265
	i32 97, ; 266
	i32 28, ; 267
	i32 226, ; 268
	i32 318, ; 269
	i32 296, ; 270
	i32 149, ; 271
	i32 211, ; 272
	i32 169, ; 273
	i32 4, ; 274
	i32 98, ; 275
	i32 179, ; 276
	i32 33, ; 277
	i32 93, ; 278
	i32 273, ; 279
	i32 198, ; 280
	i32 21, ; 281
	i32 41, ; 282
	i32 170, ; 283
	i32 312, ; 284
	i32 244, ; 285
	i32 304, ; 286
	i32 258, ; 287
	i32 289, ; 288
	i32 283, ; 289
	i32 263, ; 290
	i32 2, ; 291
	i32 134, ; 292
	i32 111, ; 293
	i32 199, ; 294
	i32 324, ; 295
	i32 213, ; 296
	i32 321, ; 297
	i32 58, ; 298
	i32 95, ; 299
	i32 303, ; 300
	i32 39, ; 301
	i32 224, ; 302
	i32 25, ; 303
	i32 94, ; 304
	i32 89, ; 305
	i32 99, ; 306
	i32 10, ; 307
	i32 87, ; 308
	i32 100, ; 309
	i32 270, ; 310
	i32 183, ; 311
	i32 290, ; 312
	i32 215, ; 313
	i32 300, ; 314
	i32 7, ; 315
	i32 255, ; 316
	i32 295, ; 317
	i32 173, ; 318
	i32 212, ; 319
	i32 88, ; 320
	i32 185, ; 321
	i32 250, ; 322
	i32 154, ; 323
	i32 299, ; 324
	i32 33, ; 325
	i32 195, ; 326
	i32 116, ; 327
	i32 82, ; 328
	i32 20, ; 329
	i32 11, ; 330
	i32 162, ; 331
	i32 3, ; 332
	i32 208, ; 333
	i32 307, ; 334
	i32 201, ; 335
	i32 199, ; 336
	i32 84, ; 337
	i32 294, ; 338
	i32 64, ; 339
	i32 309, ; 340
	i32 277, ; 341
	i32 143, ; 342
	i32 259, ; 343
	i32 157, ; 344
	i32 41, ; 345
	i32 117, ; 346
	i32 184, ; 347
	i32 214, ; 348
	i32 303, ; 349
	i32 329, ; 350
	i32 266, ; 351
	i32 131, ; 352
	i32 75, ; 353
	i32 66, ; 354
	i32 313, ; 355
	i32 172, ; 356
	i32 174, ; 357
	i32 218, ; 358
	i32 143, ; 359
	i32 106, ; 360
	i32 151, ; 361
	i32 70, ; 362
	i32 156, ; 363
	i32 183, ; 364
	i32 121, ; 365
	i32 127, ; 366
	i32 308, ; 367
	i32 152, ; 368
	i32 241, ; 369
	i32 177, ; 370
	i32 141, ; 371
	i32 228, ; 372
	i32 305, ; 373
	i32 20, ; 374
	i32 14, ; 375
	i32 204, ; 376
	i32 135, ; 377
	i32 75, ; 378
	i32 59, ; 379
	i32 231, ; 380
	i32 167, ; 381
	i32 168, ; 382
	i32 206, ; 383
	i32 15, ; 384
	i32 74, ; 385
	i32 6, ; 386
	i32 23, ; 387
	i32 253, ; 388
	i32 212, ; 389
	i32 176, ; 390
	i32 91, ; 391
	i32 306, ; 392
	i32 1, ; 393
	i32 136, ; 394
	i32 254, ; 395
	i32 276, ; 396
	i32 134, ; 397
	i32 69, ; 398
	i32 178, ; 399
	i32 146, ; 400
	i32 192, ; 401
	i32 315, ; 402
	i32 294, ; 403
	i32 245, ; 404
	i32 200, ; 405
	i32 88, ; 406
	i32 96, ; 407
	i32 235, ; 408
	i32 240, ; 409
	i32 310, ; 410
	i32 31, ; 411
	i32 45, ; 412
	i32 249, ; 413
	i32 214, ; 414
	i32 109, ; 415
	i32 158, ; 416
	i32 35, ; 417
	i32 22, ; 418
	i32 114, ; 419
	i32 180, ; 420
	i32 57, ; 421
	i32 274, ; 422
	i32 144, ; 423
	i32 118, ; 424
	i32 120, ; 425
	i32 110, ; 426
	i32 216, ; 427
	i32 139, ; 428
	i32 176, ; 429
	i32 222, ; 430
	i32 54, ; 431
	i32 105, ; 432
	i32 316, ; 433
	i32 207, ; 434
	i32 208, ; 435
	i32 133, ; 436
	i32 288, ; 437
	i32 279, ; 438
	i32 267, ; 439
	i32 322, ; 440
	i32 245, ; 441
	i32 210, ; 442
	i32 159, ; 443
	i32 301, ; 444
	i32 232, ; 445
	i32 163, ; 446
	i32 132, ; 447
	i32 267, ; 448
	i32 161, ; 449
	i32 314, ; 450
	i32 182, ; 451
	i32 256, ; 452
	i32 140, ; 453
	i32 279, ; 454
	i32 275, ; 455
	i32 169, ; 456
	i32 209, ; 457
	i32 217, ; 458
	i32 284, ; 459
	i32 40, ; 460
	i32 243, ; 461
	i32 81, ; 462
	i32 179, ; 463
	i32 56, ; 464
	i32 37, ; 465
	i32 97, ; 466
	i32 166, ; 467
	i32 172, ; 468
	i32 195, ; 469
	i32 280, ; 470
	i32 82, ; 471
	i32 219, ; 472
	i32 98, ; 473
	i32 30, ; 474
	i32 159, ; 475
	i32 18, ; 476
	i32 127, ; 477
	i32 202, ; 478
	i32 119, ; 479
	i32 239, ; 480
	i32 270, ; 481
	i32 252, ; 482
	i32 272, ; 483
	i32 190, ; 484
	i32 165, ; 485
	i32 247, ; 486
	i32 330, ; 487
	i32 269, ; 488
	i32 260, ; 489
	i32 170, ; 490
	i32 16, ; 491
	i32 144, ; 492
	i32 307, ; 493
	i32 125, ; 494
	i32 118, ; 495
	i32 38, ; 496
	i32 115, ; 497
	i32 47, ; 498
	i32 142, ; 499
	i32 117, ; 500
	i32 34, ; 501
	i32 175, ; 502
	i32 95, ; 503
	i32 53, ; 504
	i32 261, ; 505
	i32 129, ; 506
	i32 153, ; 507
	i32 24, ; 508
	i32 161, ; 509
	i32 238, ; 510
	i32 148, ; 511
	i32 104, ; 512
	i32 89, ; 513
	i32 226, ; 514
	i32 60, ; 515
	i32 142, ; 516
	i32 100, ; 517
	i32 5, ; 518
	i32 13, ; 519
	i32 122, ; 520
	i32 135, ; 521
	i32 28, ; 522
	i32 302, ; 523
	i32 72, ; 524
	i32 236, ; 525
	i32 24, ; 526
	i32 224, ; 527
	i32 265, ; 528
	i32 262, ; 529
	i32 319, ; 530
	i32 137, ; 531
	i32 217, ; 532
	i32 233, ; 533
	i32 168, ; 534
	i32 266, ; 535
	i32 298, ; 536
	i32 101, ; 537
	i32 123, ; 538
	i32 237, ; 539
	i32 193, ; 540
	i32 185, ; 541
	i32 188, ; 542
	i32 163, ; 543
	i32 167, ; 544
	i32 240, ; 545
	i32 39, ; 546
	i32 205, ; 547
	i32 306, ; 548
	i32 178, ; 549
	i32 17, ; 550
	i32 171, ; 551
	i32 319, ; 552
	i32 318, ; 553
	i32 137, ; 554
	i32 150, ; 555
	i32 229, ; 556
	i32 204, ; 557
	i32 155, ; 558
	i32 130, ; 559
	i32 19, ; 560
	i32 65, ; 561
	i32 147, ; 562
	i32 47, ; 563
	i32 326, ; 564
	i32 215, ; 565
	i32 79, ; 566
	i32 61, ; 567
	i32 106, ; 568
	i32 264, ; 569
	i32 219, ; 570
	i32 49, ; 571
	i32 250, ; 572
	i32 323, ; 573
	i32 261, ; 574
	i32 14, ; 575
	i32 184, ; 576
	i32 68, ; 577
	i32 171, ; 578
	i32 225, ; 579
	i32 229, ; 580
	i32 328, ; 581
	i32 78, ; 582
	i32 234, ; 583
	i32 108, ; 584
	i32 218, ; 585
	i32 187, ; 586
	i32 260, ; 587
	i32 67, ; 588
	i32 182, ; 589
	i32 63, ; 590
	i32 27, ; 591
	i32 160, ; 592
	i32 186, ; 593
	i32 227, ; 594
	i32 10, ; 595
	i32 205, ; 596
	i32 11, ; 597
	i32 78, ; 598
	i32 126, ; 599
	i32 83, ; 600
	i32 189, ; 601
	i32 66, ; 602
	i32 107, ; 603
	i32 65, ; 604
	i32 128, ; 605
	i32 122, ; 606
	i32 77, ; 607
	i32 275, ; 608
	i32 265, ; 609
	i32 327, ; 610
	i32 8, ; 611
	i32 233, ; 612
	i32 2, ; 613
	i32 44, ; 614
	i32 278, ; 615
	i32 156, ; 616
	i32 128, ; 617
	i32 263, ; 618
	i32 23, ; 619
	i32 133, ; 620
	i32 221, ; 621
	i32 252, ; 622
	i32 322, ; 623
	i32 304, ; 624
	i32 29, ; 625
	i32 220, ; 626
	i32 211, ; 627
	i32 62, ; 628
	i32 207, ; 629
	i32 90, ; 630
	i32 87, ; 631
	i32 0, ; 632
	i32 148, ; 633
	i32 209, ; 634
	i32 36, ; 635
	i32 86, ; 636
	i32 241, ; 637
	i32 317, ; 638
	i32 312, ; 639
	i32 188, ; 640
	i32 50, ; 641
	i32 6, ; 642
	i32 90, ; 643
	i32 324, ; 644
	i32 21, ; 645
	i32 162, ; 646
	i32 96, ; 647
	i32 50, ; 648
	i32 113, ; 649
	i32 257, ; 650
	i32 130, ; 651
	i32 76, ; 652
	i32 27, ; 653
	i32 234, ; 654
	i32 256, ; 655
	i32 7, ; 656
	i32 206, ; 657
	i32 110, ; 658
	i32 257, ; 659
	i32 194, ; 660
	i32 243 ; 661
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.2xx @ 96b6bb65e8736e45180905177aa343f0e1854ea3"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
