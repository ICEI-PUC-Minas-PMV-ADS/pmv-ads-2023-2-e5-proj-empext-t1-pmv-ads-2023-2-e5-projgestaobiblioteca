import { formatDate } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { DateAdapter } from "@angular/material/core";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Emprestimo, FiltroEmprestimo, EmprestimoService, Status } from "src/app/emprestimos";
import { Paginacao } from "src/app/shared";
import { Usuario, UsuarioService } from "src/app/usuarios";

@Component({
  selector: "app-home-admin",
  templateUrl: "./homeAdmin.component.html",
  styleUrls: ["./homeAdmin.component.scss"],
})
export class HomeAdminComponent implements OnInit {
  public emprestimos: Emprestimo[] = [];
  public filtroEmprestimo: FiltroEmprestimo;
  public usuarios: Usuario[] = [];

  public paginacao = {} as Paginacao;

  public exibirImagem: boolean = true;

  dataInicio: Date;
  dataFim: Date;
  selectedUser: string;
  selectedSituaco: Status;
  showUserDropdown: boolean = false;
  showStatusDropdown: boolean = false;
  usuario: string[] = [];
  status: string[] = [];

  selectedUsers: { [key: string]: boolean} = {};
  selectedStatus: { [key: string]: boolean} = {};

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private emprestimoService: EmprestimoService,
    private usuarioService: UsuarioService,
    private dateAdapter: DateAdapter<any>
  ) {this.dateAdapter.setLocale('pt-br')}

  ngOnInit(): void {
    this.getAllEmprestimos()
    this.getAllUsuarios()
    this.obterSituacoes()
    this.filtroEmprestimo = new FiltroEmprestimo
    this.selectedUsers = {};
    this.selectedStatus = {};
    this.showUserDropdown = false;
    this.showStatusDropdown = false;
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  toggleUserDropdown() {
    this.showUserDropdown = !this.showUserDropdown
  }

  toggleStatusDropdown() {
    this.showStatusDropdown = !this.showStatusDropdown
  }

  onUserOptionChange() {
    // Lógica adicional, se necessário
  }

  public getAllEmprestimos(): void {
    this.spinnerService.show();

    this.emprestimoService
      .getAllEmprestimos()
      .subscribe(
        (retorno: Emprestimo[]) => {
          this.emprestimos = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os empréstimos", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getEmprestimosFiltrados(dataInicio: Date, dataFim: Date, selectedUsers: { [key: string]: boolean} = {}, selectedStatus: { [key: string]: boolean} = {}): void {
    this.spinnerService.show();

    let usuarioParametro: any = ""
    let listaDeUsuarios: any = ""
    let statusParametro: any = ""
    let listaDeStatus: any = ""

    Object.keys(selectedUsers).forEach(user =>{
        usuarioParametro = `&Usuarios=${user}`
        listaDeUsuarios += usuarioParametro
    })

    Object.keys(selectedStatus).forEach(status =>{
      statusParametro = `&Status=${status}`
      listaDeStatus += statusParametro
  })

    this.filtroEmprestimo.dataInicio = formatDate(dataInicio, "YYYY-MM-dd","en-US")
    this.filtroEmprestimo.dataFim = formatDate(dataFim, "YYYY-MM-dd","en-US")
    this.filtroEmprestimo.usuarios = listaDeUsuarios
    this.filtroEmprestimo.status = listaDeStatus

    this.emprestimoService
      .getEmprestimosFiltrados(this.filtroEmprestimo)
      .subscribe(
        (retorno: Emprestimo[]) => {
          this.emprestimos = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os empréstimos filtrados", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getAllUsuarios(): void {
    this.spinnerService.show();

    this.usuarioService
      .getAllUsuarios()
      .subscribe(
        (retorno: Usuario[]) => {
          this.usuarios = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os usuários", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public obterSituacoes(): void{

    this.status = ["Reservado","Emprestado","Devolvido","Renovado","Recusado"]
   
  }

  public formatarData(data: Date): any{

    if (data != null){
      var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")
    } else{
      dataFormatada = null
    }
    return dataFormatada
  }

  public obterStatus(emprestimo: Emprestimo): any {
    
    let dataAtual = new Date()
    let dataPrevistaDevolucao = emprestimo.dataPrevistaDevolucao;

    if (dataPrevistaDevolucao < dataAtual &&
      emprestimo.dataDevolucao == null && (emprestimo.status == 2 || emprestimo.status == 4)
    ) {
      return "Em atraso";
    }
      else if (emprestimo.status == 1) {
      return "Reservado";
    } else if (emprestimo.status == 2) {
      return "Emprestado";
    } else if (emprestimo.status == 3) {
      return "Devolvido";
    } else if (emprestimo.status == 4) {
      return "Renovado";
    } else if (emprestimo.status == 5) {
      return "Recusado";
    } else return "-";
}
}
