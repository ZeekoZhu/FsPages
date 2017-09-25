namespace FsPages.PostProvider

open System.IO
open System

type IPostProvider =
    abstract ListAll : int -> int -> string list
    abstract GetOne : string -> string


