/// <reference types="cypress" />
/* eslint-disable */

export class BasePageObject {
  baseUrl = 'http://localhost:3000';

  visit() {
    cy.visit(this.baseUrl);
  }
}
