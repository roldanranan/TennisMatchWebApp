var tennis_playerInsert = function (data, onSuccess, onError) {
    var url = "/api/tennis/player";

    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: JSON.stringify(data)
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

var tennis_matchInsert = function (data, onSuccess, onError) {
    var url = "/api/tennis/match";

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

var tennis_matchUpdate = function (id, data, onSuccess, onError) {

    var url = "/api/tennis/match/" + id;
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: data
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };

    $.ajax(url, settings);
}

var tennis_matchSearch = function (data, onSuccess, onError) {

    var url = "/api/tennis/search/";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , data: data
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };

    $.ajax(url, settings);
}

var tennis_GetMatches = function (onSuccess, onError) {

    var url = "/api/tennis/matches";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);
}

var tennis_GetLocation = function (onSuccess, onError) {

    var url = "/api/tennis/location";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);
}

var tennis_GetPlayers = function (onSuccess, onError) {

    var url = "/api/tennis/players";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);
}

var tennis_matchDelete = function (id, onSuccess, onError) {

    var url = "/api/tennis/match/" + id + "/delete";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "DELETE"
    };

    $.ajax(url, settings);
}

var tennis_GetSearchBar = function (onSuccess, onError) {

    var url = "/api/tennis/search/data";
    var settings = {
        cache: false
    , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);
}