#language: pt-br

Funcionalidade: Acessar API omdbapi
	Teste de endpoint da api 'http://www.omdbapi.com/'
	Passando os parametros e apikey
	Devo receber os valores correspondentes de cada filme solicitado

Cenario: 1) Requisitar informações de uma api
	Dado a url 'http://www.omdbapi.com/' com id 'tt1285016' e apikey '52ec71bf'
	E se a resposta for 200
	Entao devo ser capaz de receber o 'titulo', 'ano' e 'idioma' do filme

Cenario: 2) Validar filme inexistente
	Dado a url 'http://www.omdbapi.com/' com id 'tt128234216' e apikey '52ec71bf'
	E se a resposta for 200
	E o filme não existir
	Então devo receber uma resposta que não existe o filme catalogado