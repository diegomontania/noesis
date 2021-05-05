#language: pt-br

#para funcionamento correto do specflow no visual studio :
#https://stackoverflow.com/a/60182827

Funcionalidade: Acessar site unimed
	Teste de acesso do site 'https://www.unimed.coop.br/'
	Realizar pesquisa  de médicos em uma localidade
	Validar apresentação dos resultados com a especialidade e cidade

Cenario: 1) Acessar site e validar ações
	Dado a url 'https://www.unimed.coop.br/'
	E acessar guia medico
	Quando realizar uma pesquisa de 'médico' no Rio de Janeiro
	Entao devo ser capaz de visualizar os resultados com especialidade e cidade

Cenario: 2) Validar campos
	Dado a url 'https://www.unimed.coop.br/'
	E acessar guia medico
	Quando realizar uma pesquisa de 'médico' no Rio de Janeiro
	Entao devo ser capaz de navegar nas paginas 1, 2 e 3 não visualizar nenhum resultado com cidade 'São Paulo'
