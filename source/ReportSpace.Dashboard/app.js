var app = {};



app.path = function (rest_query) {

    var rest_path = window.location.pathname + rest_query;

    if (app.pages.indexOf(rest_query) == 0) {
        app.pages.push(rest_query);
    }

    if (rest_path.indexOf('//') == 0) {
        rest_path = rest_path.replace('//', '/');
    }

    return rest_path;
};

app.navigate = function (rest_query) {
    window.location = app.path(rest_query);
};



app.pages = [];

app.pages.Create = function (path, on_navigate) {
    var page = {};

    page.Navigate = on_navigate;
    page.path = path;

    return page;
};

app.pages.push(app.pages.Create("/index", function (model) {
    
}));

app.pages.push("/index/help")

app.pages.push("/search");

app.pages.push("/options");

app.pages.push("/login");

app.pages.push("/logout");


