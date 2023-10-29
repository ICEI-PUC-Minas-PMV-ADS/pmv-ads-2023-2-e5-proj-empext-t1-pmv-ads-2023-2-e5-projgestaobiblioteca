import { HttpClient } from '@angular/common/http'
import { Component, OnInit } from '@angular/core'

@Component({
  selector: 'app-patrimonio',
  templateUrl: './patrimonioLista.component.html',
  styleUrls: ['./patrimonioLista.component.scss']
})
export class PatrimonioListaComponent implements OnInit {
  public Patrimonio: any = []
  public PatrimonioFiltrados: any = []
  wImg: number = 50
  mImg: number = 2
  showImg: boolean = true
  private _filtroLista: string = ''

  public get filtroLista (): string {
    return this._filtroLista
  }

  public set filtroLista (value: string) {
    this._filtroLista = value
    // eslint-disable-next-line @typescript-eslint/strict-boolean-expressions
    this.PatrimonioFiltrados = this.filtroLista ? this.filtrarPatrimonio(this.filtroLista) : this.Patrimonio
  }

  // eslint-disable-next-line @typescript-eslint/explicit-function-return-type
  filtrarPatrimonio (filtro: string) {
    filtro = filtro.toLocaleLowerCase()
    return this.Patrimonio.filter((l: { nome: string, genero: string, categoria: string }) =>
    // eslint-disable-next-line @typescript-eslint/prefer-includes
      l.nome.toLocaleLowerCase().indexOf(filtro) !== -1 ||
        l.genero.toLocaleLowerCase().includes(filtro) ||
        l.categoria.toLocaleLowerCase().includes(filtro))
  }

  constructor (private http: HttpClient) {}

  ngOnInit (): void {
    this.getPatrimonio()
  }

  // eslint-disable-next-line @typescript-eslint/explicit-function-return-type
  altImg () {
    this.showImg = !this.showImg
  }

  public getPatrimonio (): void {
    this.http.get('https://localhost:7289/Biblioteca').subscribe(
      response => {
        this.Patrimonio = response
        this.PatrimonioFiltrados = this.Patrimonio
      },
      error => { console.log(error) }
    )
  }
}
