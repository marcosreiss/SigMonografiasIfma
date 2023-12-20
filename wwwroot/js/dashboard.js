//deixar item de menu selecionado
var menuItem = document.querySelectorAll('.item-menu');

function selectLink() {
    menuItem.forEach((item) =>
        item.classList.remove('ativo')
    )
    this.classList.add('ativo')
}

menuItem.forEach((item) => {
    item.addEventListener('click', selectLink)
})

//abrir ou fechar menu lateral 

var btnExp = document.querySelector('#btn-exp'); //botão de expandir
var menuSide = document.querySelector('.menu-lateral'); //toda a barra lateral

btnExp.addEventListener('click', function () { //adicionado evento ao clicar
    menuSide.classList.toggle('expandir'); //toggle: se tiver a classe, remose, se não, adiciona
});