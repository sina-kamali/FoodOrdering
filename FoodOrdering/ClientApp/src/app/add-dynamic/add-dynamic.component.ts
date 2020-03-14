import { Component, Input, OnInit, ViewChild, ComponentFactoryResolver } from '@angular/core';
import {DynamicDirective} from '../dynamic.directive';
import {ArraysHelper} from '../helpers/ArraysHelper';

@Component({
  selector: 'app-add-dynamic',
  templateUrl: './add-dynamic.component.html',
  styleUrls: ['./add-dynamic.component.css']
})
export class AddDynamicComponent implements OnInit {
  @ViewChild(DynamicDirective, {static: true}) adHost: DynamicDirective;
  private component: any ;
  @Input() set template(component: any ) {
    this.component = component;
    this.loadComponent();
  }
  private componentInputs: [];
  @Input() set templateInputs(inputs: []) {
    this.componentInputs = inputs;
    this.loadComponent();
  }
  watch: any;
  constructor(private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    this.loadComponent();
  }
  loadComponent() {

    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.component);

    const viewContainerRef = this.adHost.viewContainerRef;
    viewContainerRef.clear();

    const componentRef = viewContainerRef.createComponent(componentFactory);
    ArraysHelper.forEach(this.componentInputs, function (input: any) {
      if (componentRef.instance[input.key] != undefined) {
        componentRef.instance[input.key] = input.value;
      }
    } );
  }
}
