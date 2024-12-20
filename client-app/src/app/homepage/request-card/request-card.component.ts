import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-request-card',
  standalone: true,
  imports: [],
  templateUrl: './request-card.component.html',
  styleUrl: './request-card.component.css'
})
export class RequestCardComponent {
  @Input() request_id = 0
  @Input() title = ''
  @Input() assigned_to = ''
  @Input() assigned_by = ''
  @Input() date_assigned = ''
  @Input() date_due = ''
  @Input() level_of_severity = ''
  @Input() request_description = ''
}
