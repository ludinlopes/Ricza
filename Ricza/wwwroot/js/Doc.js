document.addEventListener("DOMContentLoaded", function () {
    const tablaDetalle = document.getElementById("detalle");
    const btnAgregarLinea = document.getElementById("agregarLinea");
    const formulario = document.getElementById("factura-form");

    let filaIndex = 2; // El índice de la próxima fila a agregar (comienza en 2 porque ya existe una fila)

    // Función para calcular el total de línea y actualizar el campo correspondiente
    function calcularTotalLinea(fila) {
        const cantidad = parseFloat(fila.querySelector("input[name^='cantidad']").value);
        const precioUnitario = parseFloat(fila.querySelector("input[name^='precioUnitario']").value);
        const descuento = parseFloat(fila.querySelector("input[name^='descuento']").value);

        const totalLinea = cantidad * precioUnitario * (1 - descuento / 100);
        fila.querySelector("input[name^='totalLinea']").value = totalLinea.toFixed(2);

        // Recalcular el total del documento y el total del IVA
        calcularTotales();
    }

    // Función para calcular el total del documento y el total del IVA
    function calcularTotales() {
        let totalDocumento = 0;
        let totalIVA = 0;

        tablaDetalle.querySelectorAll("tbody tr").forEach((fila) => {
            const totalLinea = parseFloat(fila.querySelector("input[name^='totalLinea']").value);
            totalDocumento += totalLinea;
        });

        totalIVA = totalDocumento * 0.12; // El 12% del total del documento

        document.getElementById("total-documento").value = totalDocumento.toFixed(2);
        document.getElementById("total-iva").value = totalIVA.toFixed(2);
    }

    btnAgregarLinea.addEventListener("click", function () {
        const nuevaFila = document.createElement("tr");
        nuevaFila.innerHTML = `
            <td><input type="text" name="producto${filaIndex}" required style="width:60px;"></td>
            <td><input type="text" name="nombre${filaIndex}" required style="width:300px;"></td>
            <td><input type="number" name="cantidad${filaIndex}" required style="width:40px; text-align: center;"></td>
            <td><input type="decimal" name="descuento${filaIndex}" required style="width:50px; text-align: center;" value=0></td>
            <td><input type="decimal" name="precioUnitario${filaIndex}" step="0.01" required style="width:60px; text-align: center;"></td>
            <td><input type="decimal" name="totalLinea${filaIndex}" readonly style="width:100px; text-align: center;"></td>
            <td><button type="button" class="eliminar">Eliminar</button></td>
            
        `;

        tablaDetalle.querySelector("tbody").appendChild(nuevaFila);
        filaIndex++;
    });

    tablaDetalle.addEventListener("input", function (e) {
        if (e.target.matches("input[name^='cantidad'], input[name^='descuento'], input[name^='precioUnitario']")) {
            calcularTotalLinea(e.target.closest("tr"));
        }
    });

    tablaDetalle.addEventListener("click", function (e) {
        if (e.target.classList.contains("eliminar")) {
            e.target.closest("tr").remove();
            calcularTotales();
        } /*else if (e.target.classList.contains("editar")) {
            // Agrega lógica para editar la fila si lo deseas
        }*/
    });

    formulario.addEventListener("submit", function (e) {
        e.preventDefault();
        // Aquí puedes agregar la lógica para enviar el formulario si es necesario
    });
});
