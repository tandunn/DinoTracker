import Controller from "@ember/controller";
import { tracked } from "@glimmer/tracking";
import { action } from '@ember/object';
import { inject as service } from "@ember/service";
import ApolloRepository from "dino-tracker/services/apollo-repository";
import Authentication from "dino-tracker/services/authentication";

export default class LoginController extends Controller
{
  @service router: any;
  @service apolloRepository!: ApolloRepository;
  @service authentication!: Authentication;

  @tracked username = '';
  @tracked password = '';
  @tracked isDisplayingErrorMessage = false;

  @action
  async authenticate()
  {
    let variables = { username: this.username, password: this.password };

    try
    {
      let response = await this.apolloRepository.login(variables);
      if (response == true)
      {
        this.authentication.isLoggedIn = true;
        this.authentication.username = this.username;
        this.router.transitionTo("staff");
      }
      else
      {
        this.isDisplayingErrorMessage = true;
      }
    }
    catch
    {
      this.isDisplayingErrorMessage = true;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your controllers.
declare module "@ember/controller" {
  interface Registry {
    login: LoginController;
  }
}