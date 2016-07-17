# KreatorDSL

A parser of a simple DSL representing a sequence of instructions.

KreatorDSL parses a sequence of instructions into an
abstract syntax tree (AST). What to do with the AST depends
on the application, but the original intent is that each
instruction creates an object.

## Sample

```
# Kreator DSL sample
Widget                     # Instruction name.
 'x'                       # First arg.
 True $i 'o' 555 ['c', 1]  # More args (boolean, variable, string, integer, list).
 flags=[1, 2, 4]           # Named args go after regular ones.
 created=5<monthsAgo>      # Dimensioned value.
 dirs=[src->dst,           # Directions are allowed inside lists only.
  USD->EUR]                # Single line comments are possible almost after each token.
 x = 2;                    # Last arg.
$g1 = Gadget 'g1@email.com';
$g2 = Gadget 'g2@email.com';
Connnection $g1 $g1 state='active';
```

## Building

    > build.cmd

[![Appveyor build status](https://ci.appveyor.com/api/projects/status/p0weg2j1hy02dga1?svg=true)](https://ci.appveyor.com/project/otto-gebb/kreatordsl)

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
