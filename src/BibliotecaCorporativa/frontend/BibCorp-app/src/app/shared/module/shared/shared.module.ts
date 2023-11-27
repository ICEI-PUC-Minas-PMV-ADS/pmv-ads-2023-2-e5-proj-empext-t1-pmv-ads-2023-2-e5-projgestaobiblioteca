import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteModalComponent, NavBarComponent, TitlebarComponent } from '../..';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';



@NgModule({
  declarations: [
    DeleteModalComponent,
    NavBarComponent,
    TitlebarComponent,
  ],
  exports: [
    DeleteModalComponent,
    TitlebarComponent,
    NavBarComponent,
  ],
  imports: [
    CommonModule,
    MatDialogModule,
    MatIconModule
  ]
})
export class SharedModule { }
