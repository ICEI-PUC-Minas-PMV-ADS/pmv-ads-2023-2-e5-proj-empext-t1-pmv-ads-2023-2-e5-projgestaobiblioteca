/* eslint-disable */

import { Component, OnInit, TemplateRef } from '@angular/core';
// import { ModalModule } from 'ngx-bootstrap/modal';
import { Patrimonio } from 'src/app/models';
import { Acervo } from 'src/app/models';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { MinhasReservasService } from 'src/app/services/minhasReservas/minhasReservas.service';


@Component({
  selector: 'app-minhasReservas',
  templateUrl: './minhasReservas.component.html',
  styleUrls: ['./minhasReservas.component.css']
})
export class MinhasReservasComponent implements OnInit {

  // modalRef: BsModalRef;
  public acervos: Acervo[] = [];
  public acervosFiltrados: Acervo[] = [];

  public larguraImagem = 75;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    this.acervosFiltrados = this.filtroLista ? this.filtrarReservas(this.filtroLista) : this.acervos;
  }

  public filtrarReservas(filtrarPor: string): Acervo[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.acervos.filter(
      livro => livro.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      livro.autor.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private ReservasService: MinhasReservasService,
    // private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getPatrimonios();
  }


  public getPatrimonios(): void {
    this.ReservasService.getPatrimonio().subscribe({
      next: (Response: Acervo[]) => {
        this.acervos = Response;
        this.acervosFiltrados = this.acervos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

}



