# KreatorDSL

A parser of a simple DSL representing a sequence of instructions.

KreatorDSL parses a sequence of instructions into an
abstract syntax tree (AST). What to do with the AST depends
on the application, but the original intent is that each
instruction creates an object.


## Building

    > build.cmd

## Releasing

1. Switch to the master branch. Merge from develop what is needed.
1. Edit the `RELEASE_NOTES.md` file. Add an entry with the version no.,
   date and describe the changes.
   Then run these commands (substitute the correct values instead of words
   written in caps):


```
> SET github-user=USER
> SET github-pw=PASSWORD
> build.cmd Release
```

