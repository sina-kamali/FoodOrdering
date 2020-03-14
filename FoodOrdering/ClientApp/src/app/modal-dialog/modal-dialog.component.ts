import { Component, OnInit } from '@angular/core';
import {ModalService} from './modal.service';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html',
  styleUrls: ['./modal-dialog.component.css']
})
export class ModalDialogComponent implements OnInit {

  constructor(private modalService: ModalService  ) { }

  ngOnInit() {
  }

}
