---
title: "Control Flow: pattern matchinig"
weight: 600
---

{{< alert icon="🚧" >}}
This page is a draft / WIP.
{{< /alert >}}

Please have a look at [this GitHub issue](https://github.com/vide-collabo/vide/issues/4) that discusses `match` expressions and the alternative provided in Vide.

Consider this example:

```fsharp
// --------------------------------------
// This will not compile if the pages
// differ in state and structure!
// --------------------------------------

match currentPage.Value with
| Pages.Movie id -> Pages.Movie.View id
| Pages.Landing -> Pages.Landing.View ()
| Pages.Search -> Pages.Search.View ()
| Pages.Movie id -> Pages.Movie.View id
```

Like in `if/else` expressions, every branch in match-expressions has to be of the "same type". This is important to understand, and it might not be intuitively clear what "same type" means: It is the type `Vide<'value, 'state, 'context>` where value is the component's actual return `'value` (usually `unit`), but `'state` is something that is probably not the same type when partial views differ.

Additionally, there is one question that arises:

> What to do with the state of a partial view when it's currently not needed? Should it be preserved and used eventually in the future, or shall it be forgotten so that the partial is always "reset" when it's requested in the future?

Vide provides a `switch / case` concept that allows for:

* cases that show only when there's no previous case that was shown,
* cases that always show (when their condition is met; independent of previous cases),
* default case
* specify if a case shall preserve its state or reset it on show

Example:

```fsharp
vide {
    let! (viewNr : int) = chooseView

    // There are 3 views. The 2nd view's state is cleared on every show.
    // All other views retain their state.

    switch (fun x -> x = viewNr)
    |> case 0 componentWithBooleanState
    |> caseForget 1 componentWithIntState
    |> case 2 componentWithStringState
    |> caseDefault (div { "Nothing to show - this is the default case." })
}
```

More examples are [here](https://github.com/vide-collabo/Vide/blob/main/Vide.UI/Vide.UI.Fable/src/DevApp/src/UseCases/ControlFlow.fs#L90).
