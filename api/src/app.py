from flask import Flask

from .config import app_config
from .models import db
from .views.ApplicationView import application_api as application_blueprint
from .views.AlgorithmView import algorithm_api as algorithm_blueprint
from .views.ConfigurationView import configuration_api as configuration_blueprint

def create_app(env_name):
  
  app = Flask(__name__)

  app.config.from_object(app_config[env_name])

  db.init_app(app)

  app.register_blueprint(application_blueprint, url_prefix='/api/applications')
  app.register_blueprint(algorithm_blueprint, url_prefix='/api/algorithms')
  app.register_blueprint(configuration_blueprint, url_prefix='/api/configurations')

  return app