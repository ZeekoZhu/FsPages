namespace FsPages.Pages

open System;
open Microsoft.AspNetCore.Mvc.RazorPages

open FsPages.PostProvider

type IndexModel (postStore : IPostProvider) = 
    inherit PageModel()
    member val _postStore = postStore
    member val Message : string = null with get, set
    member val PostList : (string list) = [] with get, set

    member this.OnGet() =
        do this.Message <- "Hello from F#"
        do this.PostList <- this._postStore.ListAll 0 20
