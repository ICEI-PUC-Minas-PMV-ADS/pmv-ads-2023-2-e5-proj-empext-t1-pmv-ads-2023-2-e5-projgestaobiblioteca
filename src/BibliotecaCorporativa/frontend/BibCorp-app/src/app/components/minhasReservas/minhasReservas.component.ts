/* eslint-disable */

import { Component, OnInit, TemplateRef } from '@angular/core';
// import { ModalModule } from 'ngx-bootstrap/modal';
import { Patrimonio } from 'src/app/models';
import { Acervo } from 'src/app/models';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { MinhasReservasService } from 'src/app/services/minhasReservas/minhasReservas.service';
import { Emprestimo } from 'src/app/models/Emprestimos';
import { AcervoService } from 'src/app/services';
import { MatDialog } from '@angular/material/dialog';
import { ModalRenovarComponent } from './modalRenovar/modalRenovar.component';
import { AlterarLocalComponent } from './alterarLocal';


@Component({
  selector: 'app-minhasReservas',
  templateUrl: './minhasReservas.component.html',
  styleUrls: ['./minhasReservas.component.css']
})
export class MinhasReservasComponent implements OnInit {
  title = 'angular-material';

  // modalRef: BsModalRef;
  public acervos: Emprestimo[] = [];
  public acervosFiltrados: Emprestimo[] = [];


  public titulos: Acervo[] = [];
  public titulosFiltrados: Acervo[] = [];

  // public dt = new Date().toISOString();


  public larguraImagem = 75;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  public get filtroLista(): string {
    return this.filtroListado;
  }

  public set filtroLista(value: string) {
    this.filtroListado = value;
    // this.acervosFiltrados = this.filtroLista ? this.filtrarReservas(this.filtroLista) : this.acervos;

    this.titulosFiltrados = this.filtroLista ? this.filtrarReservas(this.filtroLista) : this.titulos;
  }


  public filtrarReservas(filtrarPor: string): Acervo[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.titulos.filter(
      livro => livro.titulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      livro.subTitulo.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(
    private ReservasService: MinhasReservasService,
    private AcervoService: AcervoService,
    // private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private dialogRef : MatDialog
  ) { }

  abrirDialog(){
    this.dialogRef.open(ModalRenovarComponent);
  }

  abrirDialogAlterar(){
    this.dialogRef.open(AlterarLocalComponent);
  }

  public ngOnInit(): void {
    this.spinner.show();
    // this.getPatrimonios();
    this.getEmprestimos();
    this.getAcervo();
  }


  public getEmprestimos(): void {
    this.ReservasService.getEmprestimo().subscribe({
      next: (Response: Emprestimo[]) => {
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

  public getAcervo(): void {
    this.AcervoService.getAcervos().subscribe({
      next: (Response: Acervo[]) => {
        this.titulos = Response;
        this.titulosFiltrados = this.titulos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar', 'Erro!');
      },
      complete: () => this.spinner.hide()
    });
  }

  //  public diaAtraso(emprestimo: Emprestimo): any {
  //   // hoje = new Date();
  //   let atraso = new Date(emprestimo.dataPrevistaDevolucao);

  //   // return Math.floor((date - atraso) / (1000*60*60*24))
  //   // return  (hoje - atraso)  / 1000 / 60 / 60 / 24;
  //   return Math.abs(<any>new Date() - <any>new Date(atraso));
  //  }

  // public diaAtraso(): Emprestimo[] {
  //   let atraso = this.acervos.dataPrevistaDevolucao
  //   return x
  // }

  public renovar(): any {

  }


  public status(emprestimo: Emprestimo): any {
    if (emprestimo.dataEmprestimo != null && emprestimo.dataDevolucao == null) {
      return "Emprestado"
    } else if(emprestimo.dataDevolucao != null) {
      return "Devolvido"
    } else if(emprestimo.qtdeDiasAtraso > 0 && emprestimo.dataDevolucao == null) {
      return "Em atraso"
    }
  }

}



