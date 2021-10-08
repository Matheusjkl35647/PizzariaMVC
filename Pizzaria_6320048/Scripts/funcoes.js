function recebeInfo() {
    alert("Dados recebidos");
}

function verificaNome(){

    var nome = document.getElementById("txNome").value

    if (nome.length < 3){
        document.getElementById("txAlerta").value = document.getElementById("txAlerta").value + "Nome inválido"
    }
}

function verificaFone() {

    var fone = document.getElementById("txFone").value

    if (fone.length < 3) {
        document.getElementById("txAlerta").value = document.getElementById("txAlerta").value + "Telefone inválido"
    }
}

function testaCPF() {
    var cpfCliente = document.getElementById("txCPF").value;
    if (validarCPF(cpfCliente) == false) {
        alert("CPF inválido");
    } else {
        alert("CPF cadastrado com sucesso!")
    }
}

function validarCPF(strCPF) {
    
    if (strCPF == "") {
        return false;
    }
    if (strCPF == "00000000000") { return false; }
    if (strCPF == "11111111111") { return false; }
    if (strCPF == "22222222222") { return false; }

    var sum;
    var rest;
    sum = 0;

    for (i = 1; i <= 9; i++) sum = sum + parseInt(number.substring(i - 1, i)) * (11 - i);
    rest = (sum * 10) % 11;

    if ((rest == 10) || (rest == 11)) rest = 0;
    if (rest != parseInt(number.substring(9, 10))) return false;

    sum = 0;
    for (i = 1; i <= 10; i++) sum = sum + parseInt(number.substring(i - 1, i)) * (12 - i);
    rest = (sum * 10) % 11;

    if ((rest == 10) || (rest == 11)) rest = 0;
    if (rest != parseInt(number.substring(10, 11))) return false;
    return true;
}