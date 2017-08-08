// validation.js

$(document).ready(function(){
    $("#loginValidate").validate({
        rules: {
            emailLogin: {
                required: true,
                email: true
            },
            senhaLogin: {
                required: true
            }
        },
        messages: {
            emailLogin: {
                required: "É necessário digitar seu email",
                email: "Por favor, entre com um email válido"
            },
            senhaLogin:{
                required: "É necessário digitar sua senha"
            }
        },
    });

    $("#recuperarSenhaForm").validate({
        rules:{
            emailRecuperarsenha: {
                required: true,
                email: true
            }
        },
        messages: {
            emailRecuperarsenha: {
                required: "É necessário digitar seu email",
                email: "Por favor, entre com um email válido"
            },
        }
    });

    $("#cadastroForm").validate({
        rules: {
            emailCadastro: {
                required: true,
                email: true
            },
            senhaCadastro: {
                required: true,
                minlength: 6
            },
            confirmacaoCadastro: {
                required: true,
                equalTo: "#senhaCadastro",
                minlength: 6
            },
            nomeCadastro: {
                required: true,
                minlength: 2,
                maxlength: 15
            },
            sobrenomeCadastro: {
                required: true,
                minlength: 2
            },
            nascimentoCadastro: {
                required: true,
            },
            alturaCadastro: {
                required: true,
                min: 50,
                max: 250
            },
            sexoCadastro: {
                required: true
            }
        },
        messages: {
            emailCadastro: {
                required: "É necessário digitar o email",
                email: "Por favor, digite um email válido"
            },
            senhaCadastro: {
                required: "É necessário digitar uma senha",
                minlength: "Sua senha deve ter no mínimo 6 caracteres"
            },
            confirmacaoCadastro: {
                required: "É necessário confirmar sua senha",
                equalTo: "As senhas não correspondem",
                minlength: "Sua senha deve ter no mínimo 6 caracteres"
            },
            nomeCadastro: {
                required: "É necessário digitar seu nome",
                minlength: "Seu nome deve ter no mínimo 2 caracteres",
                maxlength: "Seu nome deve ter no máximo 15 caracteres",
            },
            sobrenomeCadastro: {
                required: "É necessário digitar seu sobrenome",
                minlength: "Seu sobrenome deve ter no mínimo 2 caracteres"
            },
            nascimentoCadastro: {
                required: "É necessário digitar sua data de nascimento",
                date: "Por favor, entre com uma data válida",
                min: "Digite uma data maior que 01/01/1900"
            },
            alturaCadastro: {
                required: "É necessário digitar sua altura",
                min: "Sua altura deve ser maior que 50cm",
                max: "Sua altura deve ser menor que 250cm"
            },
            sexoCadastro: {
                required: "É necessário escolher seu sexo",
            }
        }
    });

    $("#pesoForm").validate({
        rules:{
            data: {
                required: true,
            },
            peso: {
                required: true,
                min: 20,
                max: 200
            }
        },
        messages:{
            data: {
                required: "É necessário digitar uma data",
            },
            peso: {
                required: "É necessário digitar um peso",
                min: "O peso mínimo é de 20 kg",
                max: "O peso máximo é de 200kg"
            }
        }
    });

    $("#exercicioForm").validate({
        rules:{
            data: {
                required: true,
            },
            horario: {
                required: true,
            },
            tipo: {
                required: true,
            },
            calorias: {
                required: true,
                min: 1
            },
            descricao: {
                minlength: 2,
                maxlength: 50
            }
        },
        messages:{
            data: {
                required: "Uma data é necessária",
            },
            horario: {
                required: "Um horário é necessário",
            },
            tipo: {
                required: "Um tipo é necessário",
            },
            calorias: {
                required: "Por favor, digite o número de calorias perdidas",
                min: "Digite um valor maior que 1"
            },
            descricao: {
                minlength: "A descrição deve ter mais de 2 caracteres",
                maxlength: "A descrição deve ter menos de 50 caracteres"
            }
        }
    });

    $("#alimentacaoForm").validate({
        rules:{
            data: {
                required: true,
            },
            horario: {
                required: true,
            },
            tipo: {
                required: true,
            },
            calorias: {
                required: true,
                min: 1
            },
            descricao: {
                minlength: 2,
                maxlength: 50
            }
        },
        messages:{
            data: {
                required: "Uma data é necessária",
            },
            horario: {
                required: "Um horário é necessário",
            },
            tipo: {
                required: "Um tipo é necessário",
            },
            calorias: {
                required: "Por favor, digite o número de calorias ingeridas",
                min: "Digite um valor maior que 1"
            },
            descricao: {
                minlength: "A descrição deve ter mais de 2 caracteres",
                maxlength: "A descrição deve ter menos de 50 caracteres"
            }
        }
    });

    $("#pressaoForm").validate({
        rules: {
            data: {
                required: true
            },
            sistolica:{
                required: true,
                min: 1
            },
            diastolica: {
                required: true,
                min: 1
            }
        },
        messages: {
            data: {
                required: "Uma data é necessária"
            },
            sistolica:{
                required: "A pressão sistólica é necessária",
                min: "Digite um valor maior que 1"
            },
            diastolica: {
                required: "A pressão diastólica é necessária",
                min: "Digite um valor maior que 1"
            }
        },
    });

    $("#usuarioForm").validate({
        rules: {
            nome: {
                minlength: 2,
                maxlength: 15
            },
            sobrenome: {
                minlength: 2
            },
            altura: {
                min: 50,
                max: 250
            }
        },
        messages: {
            nome: {
                minlength: "Digite um nome com no mínimo dois caracteres",
                maxlength: "Digite um nome com no máximo 15 caracteres"
            },
            sobrenome: {
                minlength: "Digite um nome com no mínimo dois caracteres",
            },
            nascimento: {
                min: "Digite uma data maior que 01/01/1900",
            },
            altura: {
                min: "Digite uma altura maior que 50 cm",
                max: "Digite uma altura menor que 250 cm"
            }
        },
    });

    $("#alterarsenhaForm").validate({
        rules: {
            senhaAtual: {
                required: true,
                minlength: 6
                
            }, 
            novaSenha: {
                required: true,
                minlength: 6
            }, 
            confirmarSenha: {
                required: true, 
                minlength: 6,
                equalTo: "#novaSenha"
            }
        },
        messages: {
            senhaAtual: {
                required: "É necessário digitar sua senha atual",
                minlength: "A senha atual contem mais de 6 caracteres"
                
            }, 
            novaSenha: {
                required: "É necessário digitar uma nova senha",
                minlength: "A senha deve conter no mínimo 6 caracteres"
            }, 
            confirmarSenha: {
               required: "É necessário digitar uma nova senha",
                minlength: "A senha deve conter no mínimo 6 caracteres",
                equalTo: "As senhas não correspondem"
            }
        }
    });

    jQuery.validator.addMethod("password", function( value, element ) 
    {
		return this.optional(element) || value.length >= 6 && /\d/.test(value) && /[a-z]/i.test(value);
	}, "Sua senha deve conter pelo menos uma letra e um número");
});