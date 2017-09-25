namespace FsPages.Pages

open System;
open Microsoft.AspNetCore.Mvc.RazorPages
open Markdig
open FsPages.PostProvider

type PostModel(_postStore : IPostProvider) =
    inherit PageModel()

    member val Title : string = "" with get, set
    member val Content : string = "" with get, set
    member this.OnGet title =
        do this.Title <- title
        do this.Content <- title |> _postStore.GetOne |> Markdown.ToHtml
