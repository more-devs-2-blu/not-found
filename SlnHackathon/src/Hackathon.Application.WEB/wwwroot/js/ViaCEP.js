$("#rua").change(() => {
    let rua = $("#rua").val();
    console.log(rua)
    $.ajax({
        url: `https://viacep.com.br/ws/SC/Blumenau/${rua}/json/`,
        method: 'GET',
        dataType: 'JSON',
        success: (resp) => {
            let i = 1;
            resp.forEach(location => {
                if (i == 1) {
                    console.log(location);
                    $("#bairro").val(location.bairro);
                    $("#cep").val(location.cep);
                }
                i++;
            })
        }
    })
})