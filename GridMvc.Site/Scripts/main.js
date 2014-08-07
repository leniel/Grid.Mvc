$(function() {
    SyntaxHighlighter.all();
    initCodeCuts();
});

var initCodeCuts = function() {
    $(".code-cut a.code-toggle").on("click", function() {
        $(this).closest(".code-cut").find(".syntaxhighlighter").toggle();
    });
};
     
