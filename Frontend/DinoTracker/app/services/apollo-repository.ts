import Service from '@ember/service';
import { inject as service } from '@ember/service';
import loginMutation from "dino-tracker/graphql/mutations/login.graphql";
import createPaleontologistMutation from "dino-tracker/graphql/mutations/createPaleontologist.graphql";
import createResearcherMutation from "dino-tracker/graphql/mutations/createResearcher.graphql";


export default class ApolloRepository extends Service.extend({
  // anything which *must* be merged to prototype here
}) {
  @service apollo: any;

  public async login(variables: { username: string, password: string }): Promise<boolean>
  {
    try
    {
      let response = await this.apollo.mutate({ mutation: loginMutation, variables }, "login");
      return response;
    }
    catch
    {
      return false;
    }
  }

  public async createPaleontologist(variables: { name: string, username: string }): Promise<boolean>
  {
    try
    {
      let response = await this.apollo.mutate({ mutation: createPaleontologistMutation, variables }, "createPaleontologist");
      return response;
    }
    catch
    {
      return false;
    }
  }

  public async createResearcher(variables: { name: string }): Promise<boolean>
  {
    try
    {
      let response = await this.apollo.mutate({ mutation: createResearcherMutation, variables }, "createResearcher");
      return response;
    }
    catch
    {
      return false;
    }
  }
}

// DO NOT DELETE: this is how TypeScript knows how to look up your services.
declare module '@ember/service' {
  interface Registry {
    'apollo-repository': ApolloRepository;
  }
}
