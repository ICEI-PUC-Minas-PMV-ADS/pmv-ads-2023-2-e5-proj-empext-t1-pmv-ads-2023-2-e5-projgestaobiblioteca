import { Component, OnInit } from "@angular/core";
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Acervo, AcervoService } from "src/app/acervos";
import { Patrimonio, PatrimonioService } from "src/app/patrimonios";

import { FormValidator } from "src/app/util";

@Component({
  selector: "app-acervoEdicao",
  templateUrl: "./acervoEdicao.component.html",
  styleUrls: ["./acervoEdicao.component.scss"],
})
export class AcervoEdicaoComponent implements OnInit {
  public formAcervo: FormGroup;

  public acervo: Acervo;

  public patrimonio: Patrimonio;
  public patrimonios: Patrimonio[] = [];

  public acervoParam: any = "";

  public editMode: Boolean = false;

  public capaPatrimonio: string = "../../../../assets/Images/capaDefault.png";

  public get ctrF(): any {
    return this.formAcervo.controls;
  }

  constructor(
    private activevateRouter: ActivatedRoute,
    private acervoService: AcervoService,
    private formBuilder: FormBuilder,
    private patrimonioService: PatrimonioService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {
    this.acervoParam = this.activevateRouter.snapshot.paramMap.get("id");
    this.editMode = this.acervoParam != null ? true : false;

    this.formValidator();

    if (this.editMode) {
      this.getAcervo();
    }
  }

  public formValidator(): void {
    this.formAcervo = this.formBuilder.group({
      acervoId: [""],
      isbn: [
        "",
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(13),
        ],
      ],
      qtdeAcervos: ["0"],
      genero: [
        "",
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(20),
        ],
      ],
      titulo: ["", Validators.required],
      subTitulo: [""],
      autor: ["", Validators.required],
      resumo: [
        "",
        [
          Validators.required,
          Validators.minLength(30),
          Validators.maxLength(2000),
        ],
      ],
      capaUrl: ["", Validators.required],
      anoPublicacao: [
        "",
        [Validators.required, Validators.minLength(4), Validators.maxLength(4)],
      ],
      dataCriacao: [new Date().toISOString().slice(0, 10).replace(/-/g, "")],
      editora: [
        "",
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      edicao: ["", Validators.maxLength(15)],
      qtdPaginas: ["0"],
      qtdeDisponivel: ["0"],
      qtdeEmprestada: ["0"],
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formAcervo.reset();
  }

  public saveChange(): void {
    if (this.formAcervo.valid)
      if (!this.editMode) {
        this.novoAcervo();
      } else {
        this.salvarAcervo();
      }
  }

  public getAcervo(): void {
    this.spinnerService.show();

    this.acervoService
      .getAcervoById(+this.acervoParam)
      .subscribe(
        (acervo: Acervo) => {
          this.acervo = acervo;

          this.formAcervo.patchValue(this.acervo);
          this.ctrF.acervoId.setValue(this.acervo.id);
          this.getPatrimonios();
        },
        (error: any) => {
          this.toastrService.error("Falha ao recuperar Acervo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public novoAcervo(): void {
    this.spinnerService.show();

    this.acervo = { ...this.formAcervo.value };
    console.log(this.acervo);

    this.acervo.dataCriacao = new Date()
      .toISOString()
      .slice(0, 10)
      .replace(/-/g, "");

    this.acervo.qtdeEmTransito = 0;
    this.acervo.qtdeDisponivel += 1;

    this.acervoService
      .getAcervoByISBN(this.ctrF.isbn.value)
      .subscribe(
        (acervo: Acervo) => {
          if (acervo == null) {
            this.criarAcervo();
          } else {
            this.toastrService.warning("O ISBN já existe", "Alerta!");
          }
        },
        (error: any) => {
          this.toastrService.error(
            "Falha ao verificar ISBN do acervo",
            "Erro!"
          );
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
  public criarAcervo(): void {
    console.log("Patrimonios ", this.patrimonios);
    console.log("aCervo ", this.acervo);
    this.acervoService
      .createAcervo(this.acervo)
      .subscribe(
        (novoAcervo: Acervo) => {
          for (let patrimonio of this.patrimonios) {
            patrimonio.acervoId = novoAcervo.id;
            this.updateAcervoIdPatrimonio(patrimonio);
          }
          this.toastrService.success("Acervo cadastrado!", "Sucesso!");
          window.location.reload;
          this.router.navigateByUrl(`/acervos/edicao/${novoAcervo.id}`);
        },
        (error: any) => {
          this.toastrService.error("Erro ao cadastrar Acervo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public updateAcervoIdPatrimonio(patrimonio: Patrimonio): void {
    this.patrimonioService.savePatrimonio(patrimonio).subscribe(
      (patrimonio: Patrimonio) => {},
      (error: any) => {
        this.toastrService.error("Falha ao atualizar patrimonios", "Erro!");
        console.log(error);
      }
    );
  }

  public salvarAcervo(): void {
    this.spinnerService.show();

    this.acervo = { id: this.ctrF.acervoId.value, ...this.formAcervo.value };

    this.acervoService
      .saveAcervo(this.acervo)
      .subscribe(
        (acervo: Acervo) => {
          this.toastrService.success("Acervo atualizado!", "Sucesso!");
        },
        (error: any) => {
          this.toastrService.error("Falha ao atualizar Arcervo.", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getPatrimonios(): void {
    this.spinnerService.show();

    console.log(this.ctrF.isbn.value);
    this.patrimonioService
      .getPatrimoniosByISBN(this.ctrF.isbn.value)
      .subscribe(
        (patrimonios: Patrimonio[]) => {
          if (patrimonios.length != 0) {
            console.log(patrimonios);
            this.patrimonios = patrimonios;
            this.ctrF.qtdeAcervos.setValue(this.patrimonios.length);
            if (!this.editMode) this.getGoogleBook(this.ctrF.isbn.value);
          } else
            this.toastrService.error(
              "Não existe patrimônio cadastrado para o ISBN informado",
              "Erro!"
            );
        },
        (error: any) => {
          this.toastrService.error("Falha ao recuperar Patrimonios ", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getGoogleBook(isbn: string): void {
    this.acervoService
      .getGoogleBooks(isbn)
      .subscribe(
        (book: Acervo) => {
          if (book != null) {
            this.acervo = book;
            this.formAcervo.patchValue(this.acervo);
          }
        },
        (error: any) => {
          this.toastrService.error(
            "Falha ao recuperar Acervo do Google Books ",
            "Erro!"
          );
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
