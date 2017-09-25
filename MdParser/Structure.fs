namespace FsPages.MdParser

module Structure =

    type BlockType = 
        | CodeBlock
        | HeaderBlock
        | ParaBlock
        | ReferenceBlock
        | ListBlock
        
    type Block = {
        content: string
        blockType: BlockType
    }
