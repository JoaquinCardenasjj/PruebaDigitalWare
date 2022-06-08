import { Component, OnInit } from '@angular/core';
import { TransversalService } from '../services/TransversalService';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import swalAlert from 'sweetalert2';
import { CreateFacturacionesComponent } from './create-facturaciones/create-facturaciones.component';
import DataGrid from "devextreme/ui/data_grid";
@Component({
  selector: 'app-facturaciones',
  templateUrl: './facturaciones.component.html',
  styleUrls: ['./facturaciones.component.css']
})
export class FacturacionesComponent implements OnInit {
  dataGridInstance: DataGrid;
  expanded: Boolean = true;
  listaFacturaciones: any = [];
  constructor(private _TransversalService: TransversalService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    this.cargarFacturaciones();
  }
  cargarFacturaciones() {
    this._TransversalService.getCompras().subscribe((res: any) => {
      
      if (res.exitoso) {
        this.listaFacturaciones = res.objetoResultado;
      } else {
        swalAlert.fire(res.mensaje, 'error');
      }
    })
  }
  agregarFacturacion() {
    this.openModal('crear', null);
  }
  openModal(accion: string, data: any) {
    const modalRef = this.modalService.open(CreateFacturacionesComponent, { size: 'lg', backdrop: 'static', keyboard: false });
    modalRef.componentInstance.actividad = Object.assign({}, data);
    modalRef.componentInstance.accion = accion;
    modalRef.result.then((result) => {

      this.cargarFacturaciones();
    }, (reason) => {

      this.cargarFacturaciones();
    });

  }
  editarFacturacion(actividad: any) {
    this.openModal('editar', actividad);
  }
  eliminarFacturacion(actividad: any) {

    this._TransversalService.deleteActivity(actividad.idActividad).subscribe((res: any) => {
      
      swalAlert.fire('Información', res.mensajeResponse, 'info');
      this.cargarFacturaciones();
    });

  }
 
}
