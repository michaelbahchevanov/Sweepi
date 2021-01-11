/* eslint-disable */
import { BasePageObject } from './BasePageObject';

export class HomePageObject extends BasePageObject {
  get loginButton() {
    return cy.contains(/sign in/i);
  }

  get logoutButton() {
    return cy.contains(/logout/i);
  }
}
