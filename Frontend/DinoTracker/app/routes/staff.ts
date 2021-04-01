import Route from '@ember/routing/route';

export default class Staff extends Route.extend({
    activate: function() {
        this.controllerFor('staff').send('fetchStaff');
      }
}) {
}
