import {ComponentFactoryResolver, Injectable} from '@angular/core';
declare var $: any;

@Injectable({
  providedIn: 'root'
})
export class ModalService {
  // *************** Instructions ********************
  // This modal service is using modal-dialog component
  // We can call this modal in different ways
  // 1. Call it will custom template:
  // this.modalService.show(options: object, dismissCallback: any = null)
  // options is an object which is looking for certain parameters
  // options= {
  // size: string - "modal-sm" or "modal-lg" or "modal-xl" or don't include to use the default or any class that u will adjust the modal size
  // style: {} - will get an object with javascript css styles similar to [ngStyle]
  // css : string - modal-dialog css classes
  // title: string - will hold the modal title, however if it's empty will hide the title section
  // hideTitle: boolean - will allows to hide or show the title
  // text: string - will render a text in the modal
  // template: component - will display the passed component or template (we need to make sure in app.module.ts add that component as an entryComponents)
  // templateInputs: [{key: 'component Input parameter name', value: Input parameter value}] - since we are rendering the component dynamically we need to pass the inputs parameters
  // buttons: [{class: string , style: {}, click: function , label: string}] - will hold custom buttons data
  // buttonsContainerStyle : {} - will get an object with javascript css styles similar to [ngStyle]
  // buttonsContainerClass: string - button container css classes
  // hideCancel: boolean - can hide or show cancel button
  // cancelStyle: {} - css styles for cancel button - javascript css styles similar to [ngStyle]
  // cancelClass: string - css class for cancel button
  // backdrop: boolean - Includes a modal-backdrop element. Alternatively, specify static for a backdrop which doesn't close the modal on click.
  // keyboard: boolean - Closes the modal when escape key is pressed
  // focus: boolean - Puts the focus on the modal when initialized.
  // cancelText: string - cancel button text
  // override: boolean - if we want completely use our own template and don't see bootstrap modal design set to true
  // }
  // dismissCallback: function - expects a dismiss function which will be executed when modal dismisses
  //
  // These calls are not complete yet
  // 2. this.modalService.success(message: string, title: string)
  // 3. this.modalService.info(message: string, title: string, dismissCallback: any = null)
  // 4. this.modalService.warning(message: string, title: string, dismissCallback: any = null)
  // 5. this.modalService.inputs(message: string, title: string, dismissCallback: any = null)
  // 6. this.modalService.confirm(message: string, title: string, dismissCallback: any = null, yesCallback: any = null)
  // 7. this.modalService.error(message: string, title: string, dismissCallback: any = null)


  private modalID: string;
  private modalSize: string;
  private modalStyle = {};
  private modalClass: string;
  private modalTitle: string;
  private modalBody: string;
  private modalTemplate: any;
  private templateData: [];
  private modalButtons = [];
  private modalButtonHolderStyle = {};
  private modalButtonHolderClass: string;
  private modalOptions = {
    backdrop: true,
    keyboard: true,
    focus: true
  };
  private hideCancel = false;
  private hideTitle = false;
  private override = false;
  private isOpen = false;
  private cancelText = 'Close';
  private cancelStyle = {};
  private cancelClass: string;
  private modalType: modalType;
  constructor(private componentFactoryResolver: ComponentFactoryResolver) {
    this.modalID = 'defaultModal';
    this.modalSize = '';
  }

  public show = (options: object, dismissCallback: any = null): void => {
    this.modalType = modalType.custom;
    if (options != null) {
      this.setModalProperties(options);
      this.showModal(dismissCallback);
    }
  }
  public success = (message: string, title: string): void => {
    this.modalType = modalType.success;
    this.modalTitle = title;
    this.modalBody = message;
    this.cancelText = 'OK';
    this.showModal();
  }
  public info = (message: string, title: string, dismissCallback: any = null): void => {
    this.modalType = modalType.info;
    this.modalTitle = title;
    this.modalBody = message;
    this.cancelText = 'OK';
    this.showModal(dismissCallback);
  }
  public warning = (message: string, title: string, dismissCallback: any = null): void => {
    this.modalType = modalType.warning;
    this.modalTitle = title;
    this.modalBody = message;
    this.cancelText = 'OK';
    this.showModal(dismissCallback);
  }
  public inputs = (message: string, title: string, dismissCallback: any = null): void => {
    this.modalType = modalType.inputs;
    this.modalTitle = title;
    this.modalBody = message;
    this.cancelText = 'OK';
    this.showModal(dismissCallback);
  }
  public confirm = (message: string, title: string, dismissCallback: any = null, yesCallback: any = null): void => {
    this.modalType = modalType.confirm;
    this.modalTitle = title;
    this.modalBody = message;
    if (yesCallback != null) {
      this.modalButtons = [];
      const btn = {
        label: 'Yes',
        click: yesCallback,
        cssClass: 'btn-fancy-blue',
        primary: true,
        cssStyle: ''
      };
      this.modalButtons.push(btn);
    }
    this.cancelText = 'Close';
    this.showModal(dismissCallback);
  }
  public error = (message: string, title: string, dismissCallback: any = null): void => {
    this.modalTitle = title;
    this.modalBody = message;
    this.cancelText = 'Close';
    this.showModal(dismissCallback);
  }


  private showModal(dismissCallback: any = null) {
    if (!this.isOpen) {
      this.isOpen = true;
      $(`#${this.modalID}`).modal({
        show: true,
        backdrop: this.modalOptions.backdrop,
        keyboard: this.modalOptions.keyboard,
        focus: this.modalOptions.focus,
      }).on('hidden.bs.modal', (e) => {
        if (dismissCallback != null) {
          dismissCallback();
        }
        $(`#${this.modalID}`).off('hidden.bs.modal');
        this.isOpen = false;
      });
    } else {
      console.log(`Modal is open: ${this.isOpen}`);
    }

  }

  private setModalProperties(options: any) {
    if (options.modalID != undefined) {
      this.modalID = options.modalID;
    } else {
      this.modalID = 'defaultModal';
    }
    if (options.class != undefined) {
      this.modalClass = options.class;
    } else {
      this.modalClass = '';
    }
    if (options.size != undefined) {
      this.modalSize = options.size;
    } else {
      this.modalSize = '';
    }
    if (options.style != undefined) {
      this.modalStyle = options.style;
    } else {
      this.modalStyle = {};
    }
    if (options.title != undefined) {
      this.modalTitle = options.title;
    } else {
      this.modalTitle = null;
    }
    if (options.hideTitle != undefined) {
      this.hideTitle = options.hideTitle;
    } else {
      this.hideTitle = false;
    }
    if (options.text != undefined) {
      this.modalBody = options.text;
    } else {
      this.modalBody = null;
    }
    if (options.template != undefined) {
      this.modalTemplate = options.template;
    } else {
      this.modalTemplate = null;
    }
    if (options.templateInputs != undefined) {
      this.templateData = options.templateInputs;
    } else {
      this.templateData = [];
    }
    if (options.buttons != undefined) {
      this.modalButtons = options.buttons;
    } else {
      this.modalButtons = [];
    }
    if (options.buttonsContainerStyle != undefined) {
      this.modalButtonHolderStyle = options.buttonsContainerStyle;
    } else {
      this.modalButtonHolderStyle = {};
    }
    if (options.buttonsContainerClass != undefined) {
      this.modalButtonHolderClass = options.buttonsContainerClass;
    } else {
      this.modalButtonHolderClass = null;
    }
    if (options.hideCancel != undefined) {
      this.hideCancel = options.hideCancel;
    } else {
      this.hideCancel = false;
    }
    if (options.cancelStyle != undefined) {
      this.cancelStyle = options.cancelStyle;
    } else {
      this.cancelStyle = {};
    }
    if (options.cancelClass != undefined) {
      this.cancelClass = options.cancelClass;
    } else {
      this.cancelClass = null;
    }
    if (options.backdrop != undefined) {
      this.modalOptions.backdrop = options.backdrop;
    } else {
      this.modalOptions.backdrop = true;
    }
    if (options.keyboard != undefined) {
      this.modalOptions.keyboard = options.keyboard;
    } else {
      this.modalOptions.keyboard = true;
    }
    if (options.focus != undefined) {
      this.modalOptions.focus = options.focus;
    } else {
      this.modalOptions.focus = true;
    }
    if (options.cancelText != undefined) {
      this.cancelText = options.cancelText;
    } else {
      this.cancelText = 'Close';
    }
    if (options.override != undefined) {
      this.override = options.override;
    } else {
      this.override = false;
    }
  }

  get id() {
    return this.modalID;
  }
  get size() {
    return this.modalSize;
  }
  get dialogClass() {
    return this.modalClass;
  }
  get isTitleHidden() {
    return this.hideTitle;
  }
  get isCancelButtonHidden() {
    return this.hideCancel;
  }
  get style() {
    return this.modalStyle;
  }
  get title() {
    return this.modalTitle;
  }
  get text() {
    return this.modalBody;
  }
  get template() {
    return this.modalTemplate;
  }
  get data() {
    return this.templateData;
  }
  get buttons() {
    return this.modalButtons;
  }
  get buttonsHolderClass() {
    return this.modalButtonHolderClass;
  }
  get buttonsHolderStyles() {
    return this.modalButtonHolderStyle;
  }
  get cancelLabel() {
    return this.cancelText;
  }
  get cancelStyles() {
    return this.cancelStyle;
  }
  get cancelClasses() {
    return this.cancelClass;
  }
  get type() {
    return this.modalType;
  }
  get overrideModal() {
    return this.override;
  }
}
enum modalType {
  custom = 0,
  success = 1,
  info = 2,
  warning = 3,
  inputs = 4,
  confirm = 5
}

