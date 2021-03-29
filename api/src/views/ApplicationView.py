from flask import request, json, Response, Blueprint
from ..models.ApplicationModel import ApplicationModel, ApplicationSchema

application_api = Blueprint('application_api', __name__)
application_schema = ApplicationSchema()


@application_api.route('/', methods=['POST'])
def create():
    req_data = request.get_json()

    data = application_schema.load(req_data)

    app_in_db = ApplicationModel.get_application_by_name(data.get('name'))

    if app_in_db:
        message = {
            'error': 'Application already exist, please supply another application name'}
        return custom_response(message, 400)

    application = ApplicationModel(data)
    application.save()
    application_data = application_schema.dump(application)

    return custom_response({'application': application_data}, 201)


@application_api.route('/', methods=['DELETE'])
def delete():
    apps_in_db = ApplicationModel.get_all_applications()

    for x in apps_in_db:
        x.delete()

    return custom_response({'message': 'deleted'}, 204)


@application_api.route('/<int:app_id>', methods=['GET'])
def get_by_id(app_id):
    app_in_db = ApplicationModel.get_application_by_id(app_id)

    if not app_in_db:
        return custom_response({'error': 'application not found'}, 404)

    data = application_schema.dump(app_in_db)

    return custom_response(data, 200)


@application_api.route('/', methods=['GET'])
def get_all():
    apps_in_db = ApplicationModel.get_all_applications()
    print(apps_in_db)
    data = application_schema.dump(apps_in_db, many=True)
    print(data)
    return custom_response(data, 200)


def custom_response(res, status_code):
    return Response(
        mimetype="application/json",
        response=json.dumps(res),
        status=status_code
    )
