/* eslint-disable @typescript-eslint/consistent-type-imports */
import { Component, type OnInit } from '@angular/core'
import { Acervo } from 'src/app/models'
import { AcervoService } from 'src/app/services'

@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.scss']
})
export class PrincipalComponent implements OnInit {
  public acervos: Acervo[] = []
  public acervosRecentes: Acervo[] = []
  public acervosLidos: Acervo[] = []

  constructor (
    private readonly acervoService: AcervoService
  ) { }

  ngOnInit (): void {
    this.getAcervos()
  }

  public getAcervos (): void {
    this.acervoService
    .getAcervos()
    .subscribe(
      (acervos: Acervo[]) => {
        this.acervos = acervos
        this.acervosRecentes = acervos
        this.acervosLidos = acervos
        console.log(this.acervos)
        },
        (error: any) => {
          console.error(error)
        }
      )
      .add(() => {})
  }
}
