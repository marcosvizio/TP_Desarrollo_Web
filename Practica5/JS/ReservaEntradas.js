window.onload = function () {

    const inputs = document.querySelectorAll(".textbox");

    inputs.forEach(input => {

    input.addEventListener("focus", function () {
        this.classList.add("enfocada");
    });

    input.addEventListener("blur", function () {
        this.classList.remove("enfocada");
        });
    });
}

document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");
    const nombre = document.getElementById("txtNombre");
    const dni = document.getElementById("txtDNI");
    const email = document.getElementById("txtEmail");
    const actividad = document.getElementById("ddlActividad");
    const btnReservar = document.getElementById("btnReservar");


    btnReservar.addEventListener("click", function (e) {
        if (!validarFormulario()) {
            e.preventDefault();
        }
    });

    btnLimpiar.addEventListener("click", function (e) {
        document.getElementById("txtNombre").value = "";
        document.getElementById("txtDNI").value = "";
        document.getElementById("txtEmail").value = "";
        document.getElementById("txtTelefono").value = "";
        document.getElementById("txtNacimiento").value = "";
        document.getElementById("ddlActividad").selectedIndex = 0;
    })

    function validarFormulario() {
        if (
            nombre.value.trim() === "" ||
            dni.value.trim() === "" ||
            email.value.trim() === "" ||
            actividad.selectedIndex === 0
        ) {
            alert("Por favor, completá nombre, DNI, email y seleccioná una actividad.");
            return false;
        }

        // Validar que el nombre solo tenga letras y espacios
        const nombreRegex = /^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ\s]+$/;
        if (!nombreRegex.test(nombre.value.trim())) {
            alert("El nombre no debe contener números ni símbolos.");
            return false;
        }

        // Validar estructura básica del email
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email.value.trim())) {
            alert("Ingresá un correo electrónico válido.");
            return false;
        }

        return true; // Todo válido
    }
});



