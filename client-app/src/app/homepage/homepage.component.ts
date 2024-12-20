import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HeaderComponent } from '../header/header.component'
import { RequestCardComponent } from './request-card/request-card.component'
import { Request } from '../../models/Request.model'
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [HeaderComponent, RequestCardComponent, CommonModule, FormsModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit{
  requestsList: Request[] = []
  displayCreateRequestForm: boolean = false

  formData = {
    title: '',
    severity: '',
    assigned_to: '',
    assigned_by: '',
    date_due: '',
    date_assigned: '',
    request_description: ''
  }


  displayCreateNewRequestForm(e: Event) {
    e.preventDefault()
    this.displayCreateRequestForm = true
  }

  closeForm(e: Event) {
    e.preventDefault()
    this.displayCreateRequestForm = false
  }

  submitRequest() {
    console.log(this.formData)
    //Take form off screen and process the request
    this.displayCreateRequestForm = false
    this.addNewRequest()
    this.resetFormData()
  }

  addNewRequest() {
    this.requestsList.push({ request_id: this.requestsList.length + 1, title: this.formData.title, assigned_to: this.formData.assigned_to, assigned_by: this.formData.assigned_by, date_assigned: this.formData.date_assigned, date_due: this.formData.date_due, level_of_severity: this.formData.severity, request_description: this.formData.request_description})
    console.log(this.requestsList)
  }

  resetFormData() {
    this.formData = {
      title: '',
      severity: '',
      assigned_to: '',
      assigned_by: '',
      date_due: '',
      date_assigned: '',
      request_description: ''
    }
  }


  ngOnInit() {
    this.requestsList.push({ request_id: 1, title: "Bug fix", assigned_to: "Steven", assigned_by: "Manager", date_assigned: "11/20/2024", date_due: "11/24/2024", level_of_severity: "Severe", request_description: "Routing doesn't occur when user clicks submit on the help screen." })
  }

}
