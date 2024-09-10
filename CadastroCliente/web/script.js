async function fetchClientes() {
    try {
        const response = await fetch('https://localhost:7192/Cliente');
        if (!response.ok) {
            throw new Error('Erro ao buscar clientes');
        }
        const clientes = await response.json();
        const tabela = document.getElementById('cliente-tabela');

        tabela.innerHTML = '';
        clientes.forEach(cliente => {
            const row = tabela.insertRow();
            const cellNome = row.insertCell(0);
            const cellCPF = row.insertCell(1);
            const cellEndereco = row.insertCell(2);
            const cellEstado = row.insertCell(3);
            const cellGenero = row.insertCell(4);
            const cellEditar = row.insertCell(5);
            const cellDeletar = row.insertCell(6);

            cellNome.textContent = cliente.nome;
            cellCPF.textContent = cliente.cpf;
            cellEndereco.textContent = cliente.endereco;
            cellEstado.textContent = cliente.estadoCivil;
            cellGenero.textContent = cliente.genero;

            const editarButton = document.createElement('button');
            editarButton.textContent = 'Editar';
            editarButton.classList.add('btn-editar');
            editarButton.onclick = () => editarCliente(cliente.id, cliente.nome, cliente.cpf, cliente.endereco, cliente.estadoCivil, cliente.genero);
            cellEditar.appendChild(editarButton);

            const deletarButton = document.createElement('button');
            deletarButton.textContent = 'Deletar';
            deletarButton.classList.add('btn-deletar');
            deletarButton.onclick = () => deletarCliente(cliente.id);
            cellDeletar.appendChild(deletarButton);
        });
    } catch (error) {
        console.error('Erro:', error);
    }
}

async function criarCliente() {
    const nome = document.getElementById('cliente-nome').value;
    const cpf = document.getElementById('cliente-cpf').value;
    const endereco = document.getElementById('cliente-endereco').value;
    const estadoCivil = document.getElementById('cliente-estado').value;
    const genero = document.getElementById('cliente-genero').value;

    try {
        const response = await fetch('https://localhost:7192/Cliente', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ nome: nome, cpf: cpf, endereco: endereco, estadoCivil: estadoCivil, genero: genero })
        });
        if (!response.ok) {
            throw new Error('Erro ao criar Cliente');
        }
        fetchClientes();
    } catch (error) {
        console.error('Erro:', error);
    }
}
async function editarCliente(id, nomeAtual, cpfAtual, enderecoAtual, estadoCivilAtual, generoAtual) {
    const novoNome = prompt("Editar nome do cliente:", nomeAtual);
    const novoCPF = prompt("Editar CPF do cliente:", cpfAtual);
    const novoEndereco = prompt("Editar endereço do cliente:", enderecoAtual);
    const novoEstadoCivil = prompt("Editar estado civil do cliente:", estadoCivilAtual);
    const novoGenero = prompt("Editar gênero do cliente:", generoAtual);

    if (novoNome !== null && novoCPF !== null && novoEndereco !== null && novoEstadoCivil !== null && novoGenero !== null) {
        try {
            const response = await fetch(`https://localhost:7192/Cliente/${id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    nome: novoNome,
                    cpf: novoCPF,
                    endereco: novoEndereco,
                    estadoCivil: novoEstadoCivil,
                    genero: novoGenero
                })
            });

            if (!response.ok) {
                throw new Error('Erro ao editar cliente');
            }
            fetchClientes()
        } catch (error) {
            console.error('Erro:', error);
        }
    }
}


async function deletarCliente(id) {
    const confirmar = confirm("Tem certeza que deseja deletar o cliente?");
    if (confirmar) {
        try {
            const response = await fetch(`https://localhost:7192/Cliente/${id}`, {
                method: 'DELETE'
            });
            if (!response.ok) {
                throw new Error('Erro ao deletar cliente');
            }
            fetchClientes();
        } catch (error) {
            console.error('Erro:', error);
        }
    }
}

document.addEventListener('DOMContentLoaded', (event) => {
    fetchClientes();
});
