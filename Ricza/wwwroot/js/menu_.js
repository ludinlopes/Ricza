
/*************************CARGA DE MENU*****************************************/
document.addEventListener("DOMContentLoaded", function () {

    //const pr = document.getElementById('myDiv');
    //pr.innerHTML = "Prueba";
    
    
    const menuItems = document.querySelectorAll(".menu > li");


    menuItems.forEach(function (item) {
        const submenu = item.querySelector(".submenu");
        const menuItemLink = item.querySelector("a");

        menuItemLink.addEventListener("click", function (event) {
            event.preventDefault();
            submenu.classList.toggle("active");
        });

    });

});
