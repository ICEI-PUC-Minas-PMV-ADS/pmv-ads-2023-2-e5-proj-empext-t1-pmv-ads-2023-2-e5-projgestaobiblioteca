/* eslint-disable */

import { Component, OnInit, TemplateRef } from '@angular/core';
// import { ModalModule } from 'ngx-bootstrap/modal';
import { Patrimonio } from 'src/app/models';
import { Acervo } from 'src/app/models';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { MinhasReservasService } from 'src/app/services/minhasReservas/minhasReservas.service';
import { Emprestimo } from 'src/app/models/Emprestimos';
import { AcervoService, EmprestimoService } from 'src/app/services';
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
  public emprestimos: Emprestimo[] = [];
  public emprestimosFiltrados: Emprestimo[] = [];

  public acervos: Acervo[] = [];
  public acervosFiltrados: Acervo[] = [];
  public acervo: Acervo;


  // public titulos: Acervo[] = [];
  // public titulosFiltrados: Acervo[] = [];



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
    private EmprestimoService: EmprestimoService,
    private AcervoService: AcervoService,
    // private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private dialogRef : MatDialog
  ) { }

  abrirDialog(emprestimoId: number, acervoTitulo: string, dataPrevistaDevolucao: string){
    this.dialogRef.open(ModalRenovarComponent, {
      data : { emprestimoId: emprestimoId, acervoTitulo: acervoTitulo, dataPrevistaDevolucao: dataPrevistaDevolucao, id: 'Renovar'}
      
    });

    
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
    this.EmprestimoService.getEmprestimos().subscribe({
      next: (Response: Emprestimo[]) => {
        this.emprestimos = Response;
        this.emprestimosFiltrados = this.emprestimos;
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



