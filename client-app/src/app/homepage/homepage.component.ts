import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../header/header.component'
import { RequestCardComponent } from './request-card/request-card.component'
import { Request } from '../../models/Request.model'
@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [HeaderComponent, RequestCardComponent, CommonModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent implements OnInit{
  requestsList: Request[] = []



  ngOnInit() {
    this.requestsList.push({ request_id: 1, title: "Bug fix", assigned_to: "Steven", assigned_by: "Manager", date_assigned: "11/20/2024", date_due: "11/24/2024", level_of_severity: "Severe", request_description: "Routing doesn't occur when user clicks submit on the help screen." })
  }

}
