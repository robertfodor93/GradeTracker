import { EducationType } from './educationType';
import { Module } from './module';

export class CompetenceArea {
    id?: number
    name?: string
    weighting?: number
    modules?: Module[]
    educationTypeId?: number
    educationType?: EducationType
}