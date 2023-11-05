import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalSucessoComponent } from '../modalSucesso/modalSucesso.component';

@Component({
  selector: 'app-pop-up',
  templateUrl: './modalEmprestar.component.html',
  styleUrls: ['./modalEmprestar.component.scss']
})
export class modalEmprestarComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  fecharModalEmprestarEAbrirModalSucesso() {
    const dialogRefEmprestar = this.dialog.getDialogById('Emprestar'); 
    if (dialogRefEmprestar) {
      dialogRefEmprestar.close();
    }

    this.dialog.open(ModalSucessoComponent, {
      data: {}, id: 'Sucesso'
    });
  }
}
