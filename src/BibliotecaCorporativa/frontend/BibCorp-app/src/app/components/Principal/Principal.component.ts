/* eslint-disable @typescript-eslint/consistent-type-imports */
import { Component, OnInit } from '@angular/core'

import { NgxSpinnerService } from 'ngx-spinner'
import { ToastrService } from 'ngx-toastr'

import { Acervo } from 'src/app/models'
import { AcervoService } from 'src/app/services'

import { Paginacao, ResultadoPaginado } from 'src/app/util'

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  public acervos: Acervo[] = []
  public acervosRecentes: Acervo[] = []
  public acervosLidos: Acervo[] = []
  public acervosRecentesCategoria: Acervo[] = []

  public paginacao: Paginacao[] = []

  public generos: String[] = []

  public opcaoPesquisa: string = 'Todos' 
  public opcaoGeneroRecentes: string = 'Todos'
  public argumento: string = ''

  public filtroAcervo(): void {
    this.getAcervosRecentes()
  }

  constructor (
    private acervoService: AcervoService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService
  ) { }

  public ngOnInit (): void {
    this.getAcervosRecentes()
    this.getAcervos()
  }

  public getAcervosRecentes (): void {
    this.spinnerService.show()

    this.acervoService
    .getAcervosRecentes(1, 4, this.argumento, this.opcaoPesquisa, this.opcaoGeneroRecentes)
    .subscribe(
      (retorno: ResultadoPaginado<Acervo[]>) => {
        this.acervosRecentes = retorno.resultado
      },
      (error: any) => {
        console.log("aqui 2")
        this.toastrService.error("Erro ao carregar Acervos", 'Erro!');
        console.error(error)
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public getAcervos(): void {
    this.spinnerService.show()

    this.acervoService
    .getAcervos()
    .subscribe(
      (retorno: Acervo[]) => {
        this.acervos = retorno

        for (var acervo of this.acervos)
          this.generos.push(acervo.genero)

        this.generos = this.generos.filter((genero, i) => this.generos.indexOf(genero) === i)

        this.acervosLidos = retorno
      },
      (error: any) => {
        console.log("aqui 2")
        this.toastrService.error("Erro ao carregar Acervos", 'Erro!');
        console.error(error)
      }
    )
    .add(() => this.spinnerService.hide())
  }


}
