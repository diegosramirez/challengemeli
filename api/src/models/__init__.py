from flask_sqlalchemy import SQLAlchemy

db = SQLAlchemy()

from .ApplicationModel import ApplicationModel, ApplicationSchema
from .ConfigurationModel import ConfigurationModel, ConfigurationSchema
from .AlgorithmModel import AlgorithmModel, AlgorithmSchema