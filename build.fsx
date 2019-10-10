#r "paket: groupref build //"
#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.IO


Target.create "CleanGRPCsample" (fun _ ->
    [
        "./src/gRpcSample/bin/"
        "./src/gRpcSample/obj/"
    ]
    |> Shell.cleanDirs 
)

Target.create "BuildGRPCsample" (fun _ ->
    "src/gRpcSample/gRpcSample.fsproj" |> DotNet.build id |> ignore 
) 

open Fake.Core.TargetOperators

"CleanGRPCsample"
    ==> "BuildGRPCsample"

Target.runOrDefault "BuildGRPCsample"













#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Shell.cleanDirs 
)

Target.create "Build" (fun _ ->
    !! "src/**/*.*proj"
    |> Seq.iter (DotNet.build id)
)

Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "All"

Target.runOrDefault "All"
