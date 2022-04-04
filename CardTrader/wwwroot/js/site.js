// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function changeImage() {
    var select = document.getElementById("image-select");

    var image = document.getElementById("dimg");

    var imageUrl = select.value;

    image.src = imageUrl
}