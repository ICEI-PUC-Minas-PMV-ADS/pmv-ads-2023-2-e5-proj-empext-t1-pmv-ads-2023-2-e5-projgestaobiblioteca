import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.scss']
})
export class LivrosComponent implements OnInit{

    public livros: any = [];
    public livrosFiltrados: any = [];
    wImg: number = 50;
    mImg: number = 2;
    showImg: boolean = true;
    private _filtroLista: string = '';

    public get filtroLista(): string {
      return this._filtroLista
    }

    public set filtroLista(value: string) {
      this._filtroLista = value;
      this.livrosFiltrados = this.filtroLista ? this.filtrarLivros(this.filtroLista) : this.livros;
    }

    filtrarLivros(filtro: string) {
      filtro = filtro.toLocaleLowerCase();
      return this.livros.filter(
        (l: { nome: string; genero: string; categoria: string;}) =>
        l.nome.toLocaleLowerCase().indexOf(filtro) !== -1 ||
        l.genero.toLocaleLowerCase().indexOf(filtro) !== -1 ||
        l.categoria.toLocaleLowerCase().indexOf(filtro) !== -1)
    }

    constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getLivros();
  }

  altImg() {
    this.showImg = !this.showImg
  }

  public getLivros(): void {
    this.http.get('https://localhost:7289/Biblioteca').subscribe(
      response => {
        this.livros = response;
        this.livrosFiltrados = this.livros
      },
      error => console.log(error),
    );




  }
}
