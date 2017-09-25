namespace FsPages.PostProvider

open System
open System.IO

module DiskPostProvider =
    
    let postDirectory = Path.Combine(Environment.CurrentDirectory,"Posts")

    type DiskPostProvider() =
        interface IPostProvider with
            member x.ListAll pageIndex pageSize =
                postDirectory
                |> Directory.EnumerateFiles
                |> List.ofSeq
                |> List.skip (pageIndex * pageSize)
                |> List.truncate pageSize
                |> List.map (Path.GetFileNameWithoutExtension)

            member x.GetOne name =
                let filePath = Path.Combine(postDirectory, name + ".md")
                if not (File.Exists filePath)
                then (name + "Not Found")
                else File.ReadAllText (filePath,System.Text.Encoding.UTF8)
