!function ({ $ajax }) {

    $ajax('/Movies/JsonApi/001')
        .then(res => res.getJson())
        .then(data => {
            console.log(data);
        })
        .catch(err => console.log(err));

}(dogo);