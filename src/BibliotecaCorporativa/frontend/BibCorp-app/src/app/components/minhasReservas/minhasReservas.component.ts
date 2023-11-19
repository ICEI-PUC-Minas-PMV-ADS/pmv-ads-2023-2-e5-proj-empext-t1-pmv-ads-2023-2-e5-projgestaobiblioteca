/* eslint-disable */

import { Component, OnInit, TemplateRef } from '@angular/core';
// import { ModalModule } from 'ngx-bootstrap/modal';
import { Patrimonio, UsuarioLogin } from 'src/app/models';
import { Acervo } from 'src/app/models';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { MinhasReservasService } from 'src/app/services/minhasReservas/minhasReservas.service';
import { Emprestimo } from 'src/app/models/Emprestimos';
import { AcervoService, EmprestimoService, LoginService } from 'src/app/services';
import { MatDialog } from '@angular/material/dialog';
import { ModalRenovarComponent } from './modalRenovar/modalRenovar.component';
import { AlterarLocalComponent } from './alterarLocal/alterarLocal.component';
import { NavigationEnd, Router } from '@angular/router';


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

  public usuarioLogado = false;
  public usuarioAtivo = {} as UsuarioLogin;



  public larguraImagem = 75;
  public margemImagem = 2;
  public exibirImagem = true;
  private filtroListado = '';

  //----------------------------------------------FILTROS--------------------------------------------------
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

  //----------------------------------------------VERIFICAÇÃO DE USUARIO e MÉTODOS--------------------------------------------------

constructor(
    private EmprestimoService: EmprestimoService,
    private AcervoService: AcervoService,
    // private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private dialogRef : MatDialog,
    public loginService: LoginService,
    private router: Router,
  ) {
    router.events
    .subscribe(
      (verifyUser) => {
        if (verifyUser instanceof NavigationEnd)
          this.loginService.currentUser$
            .subscribe(
              (userActive) => {
                this.usuarioLogado = userActive !== null;
                this.usuarioAtivo = { ...userActive};
              }
            )
      }
    )
   }

// DELETAR APOS VALIDAÇÃO
  // constructor(
  //   private EmprestimoService: EmprestimoService,
  //   private AcervoService: AcervoService,
  //   // private modalService: BsModalService,
  //   private toastr: ToastrService,
  //   private spinner: NgxSpinnerService,
  //   private dialogRef : MatDialog
  // ) { }

  abrirDialogRenovacao(emprestimoId: number, acervoTitulo: string, dataPrevistaDevolucao: string){
    this.dialogRef.open(ModalRenovarComponent, {
      data : { emprestimoId: emprestimoId, acervoTitulo: acervoTitulo, dataPrevistaDevolucao: dataPrevistaDevolucao, id: 'Renovar'}

    });
  }

  abrirDialogAlteracao(emprestimoId: number, localDeColetaAtual: string){
    this.dialogRef.open(AlterarLocalComponent, {
      data : { localDeColeta: localDeColeta, id: 'Alterar'}

    });
  }

  public ngOnInit(): void {
    this.spinner.show();
    // this.getPatrimonios();
    this.getEmprestimos(this.usuarioAtivo.userName);
    this.getAcervo();

    this.usuarioLogado = this.usuarioAtivo !== null;
  }


  public getEmprestimos(user: string): void {
    this.EmprestimoService.getEmprestimosByUserName(user).subscribe({
      next: (Response: Emprestimo[]) => {
        this.emprestimos = Response;
        this.emprestimosFiltrados = this.emprestimos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar lista de empréstimos do usuario.', 'Erro!');
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

// DELETAR APOS VALIDAÇÃO
  // public status(emprestimo: Emprestimo): any {
  //   if (emprestimo.dataEmprestimo != null && emprestimo.dataDevolucao == null) {
  //     return "Emprestado"
  //   } else if(emprestimo.dataDevolucao != null) {
  //     return "Devolvido"
  //   } else if(emprestimo.qtdeDiasAtraso > 0 && emprestimo.dataDevolucao == null) {
  //     return "Em atraso"
  //   }
  // }

  public status(emprestimo: Emprestimo): any {
    if (emprestimo.status == 1) {
      return "Reservado"
  }else if (emprestimo.status == 2) {
    return "Emprestado"
  } else if (emprestimo.status == 3) {
    return "Devolvido"
  } else if (emprestimo.status == 4) {
    return "Renovado"
  } else return "ERRO: Status desconhecido"

}

// DELETAR APOS VALIDAÇÃO
  // public status(emprestimo: Emprestimo): any {
  //   if (emprestimo.dataEmprestimo != null && emprestimo.dataDevolucao == null) {
  //     return "Emprestado"
  //   } else if(emprestimo.dataDevolucao != null) {
  //     return "Devolvido"
  //   } else if(emprestimo.qtdeDiasAtraso > 0 && emprestimo.dataDevolucao == null) {
  //     return "Em atraso"
  //   }
  // }



}



