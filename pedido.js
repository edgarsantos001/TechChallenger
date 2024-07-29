// JavaScript source code
document.addEventListener('DOMContentLoaded', function () {
    const pedidoFormContainer = document.getElementById('pedidoFormContainer');
    const pedidoStatusContainer = document.getElementById('pedidoStatusContainer');

    pedidoFormContainer.innerHTML = `
        <form id="pedidoForm">
            <label for="clienteId">Cliente ID:</label>
            <input type="text" id="clienteId" name="clienteId" required>
            <label for="produtoIds">Produto IDs (comma separated):</label>
            <input type="text" id="produtoIds" name="produtoIds" required>
            <button type="submit">Create Pedido</button>
        </form>
        <div id="pedidoResult"></div>
    `;

    pedidoStatusContainer.innerHTML = `
        <form id="statusForm">
            <label for="pedidoId">Pedido ID:</label>
            <input type="text" id="pedidoId" name="pedidoId" required>
            <button type="submit">Check Status</button>
        </form>
        <div id="statusResult"></div>
    `;

    document.getElementById('pedidoForm').addEventListener('submit', function (event) {
        event.preventDefault();
        createPedido();
    });

    document.getElementById('statusForm').addEventListener('submit', function (event) {
        event.preventDefault();
        checkPedidoStatus();
    });
});

function createPedido() {
    const clienteId = document.getElementById('clienteId').value;
    const produtoIds = document.getElementById('produtoIds').value.split(',').map(id => id.trim());

    const pedido = {
        clienteId: clienteId,
        produtoIds: produtoIds,
        status: 'Recebido'
    };

    fetch('http://localhost:5000/api/pedidos', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(pedido)
    })
        .then(response => response.json())
        .then(data => {
            document.getElementById('pedidoResult').innerText = 'Pedido created with ID: ' + data.id;
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

function checkPedidoStatus() {
    const pedidoId = document.getElementById('pedidoId').value;

    fetch(`http://localhost:5000/api/pedidos/${pedidoId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('statusResult').innerText = 'Status do pedido: ' + data.status;
        })
        .catch(error => {
            console.error('Error:', error);
        });
}
